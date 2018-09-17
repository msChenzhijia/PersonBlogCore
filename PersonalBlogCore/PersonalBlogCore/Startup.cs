using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Blog.Core.Common.Redis;
using Blog.Core.IServices;
using Blog.Core.Repository.sugar;
using Blog.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using PersonalBlogCore.AOP;
using PersonalBlogCore.AuthHelper.OverWrite;
using Swashbuckle.AspNetCore.Swagger;

namespace PersonalBlogCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            services.AddMvc();
            services.AddScoped<ICaching, MemoryCaching>();
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();
            #region Swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v0.1.0",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Blog.Core", Email = "Blog.Core@xxx.com", Url = "https://www.jianshu.com/u/94102b59cc2a" }
                });
               
                var xmlPath = Path.Combine(basePath, "PersonalBlogCore.xml");//这个就是刚刚配置的xml文件名
                var xmlModelPath = Path.Combine(basePath, "Blog.Core.Model.xml");
                c.IncludeXmlComments(xmlModelPath, true);
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                #region  Token绑定到ConfigureServices
                //添加header验证信息
                var security = new Dictionary<string, IEnumerable<string>>
                { {
                        "Blog.Core",new string[]{ }
                }};
                c.AddSecurityDefinition("Blog.Core", new ApiKeyScheme
                {
                    Description= "JWT授权(数据将在请求头中进行传输) 直接在下框中输入{token}\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion
               
             
                //BaseDBConfig.ConnectionString=Configuration.GetSection("AppSettings:MySqlConnection").Value;
               
            });
            #endregion
            #region CORS
            services.AddCors(c =>
            {
                //↓↓↓↓↓↓↓注意正式环境不要使用这种全开放的处理↓↓↓↓↓↓↓↓↓↓
                c.AddPolicy("AllRequests", policy =>
                {
                    policy.AllowAnyOrigin()//允许任何源
                          .AllowAnyMethod()//允许任何方式
                          .AllowAnyHeader()//允许任何头
                          .AllowCredentials();//允许cookie
                });
                //↑↑↑↑↑↑↑注意正式环境不要使用这种全开放的处理↑↑↑↑↑↑↑↑↑↑
                //一般采用这种方法
                c.AddPolicy("LimitRequests", policy =>
                {
                    //policy.WithOrigins("http://localhost:8080", "http://blog.core.personalBlogCore.com", "")//支持多个域名端口
                    policy.WithOrigins(new string[] { "http://localhost:8080", "" })
                          .WithMethods("GET", "POST", "PUT", "DELETE")//请求方法添加到策略
                          .WithHeaders("Access-Control-Allow-Origin");//标头添加到策略
                });
            });
           
            #endregion
            #region AutoFac
            //实例化AutoFac容器
            var builder = new ContainerBuilder();
            //注册要通过反射创建的组件
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();
            //var assemblysServices = Assembly.Load("Blog.Core.Services");
            //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();// 指定已扫描程序集中的类型注册为提供所有其实现的接口。
            builder.RegisterType<BlogCacheAOP>();
            var servicesDllFile = Path.Combine(basePath, "Blog.Core.Services.dll");//获取项目绝对路径
            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(BlogCacheAOP));//允许将拦截器服务的列表分配给注册。可以直接替换其他拦截器
            var repositoryDllFile = Path.Combine(basePath, "Blog.Core.Repository.dll");
            var assemblyRepository = Assembly.LoadFile(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblyRepository).AsImplementedInterfaces();


            //var assemblyRepository = Assembly.Load("Blog.Core.Repository");
            //builder.RegisterAssemblyTypes(assemblyRepository).AsImplementedInterfaces();
            //将Services填充Autofac容器生成器
            builder.Populate(services);
            var ApplicationContainer = builder.Build();
            #endregion
            return new AutofacServiceProvider(ApplicationContainer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion
            app.UseMiddleware<JwtTokenAuth>();
            app.UseCors("LimitRequests");//将 CORS 中间件添加到 web 应用程序管线中, 以允许跨域请求。有的不加也是可以的，最好是加上吧
            app.UseMvc();
        }
    }
}
