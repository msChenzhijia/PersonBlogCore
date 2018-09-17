$(function () {
    $("#jsonp").click(function () {
        $.getJSON("http://localhost:64493/api/Login/jsonp?callBack=?", function (data) {
            $("#data-jsonp").html("数据:" + data.value);
        });
    });
    $("#cors").click(function () {
        $.get("http://localhost:64493/api/Login/Token", function (data, status) {
            $("#status-cors").html("状态: " + status);
            $("#data-cors").html("数据: " + data);
        });
    });
})