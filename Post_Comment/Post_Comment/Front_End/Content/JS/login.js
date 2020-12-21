$(document).ready(function () {
    /*if (localStorage.authUser != null) {
        window.location.href = "/Front_End/Views/index.html";
    }*/

    var loadLogin = function () {
        $.ajax({
            url: "http://localhost:59954/api/users/logins",
            method: "POST",
            data: {
                username: $("#username").val(),
                password: $("#password").val()
            },
            headers: {
                'Authorization': 'Basic ' + btoa($("#username").val() + ":" + $("#password").val()),
            },
            complete: function (xhr, status) {
                if (xhr.status == 200) {

                    localStorage.authUser = btoa($("#username").val() + ":" + $("#password").val());
                    var user = xhr.responseJSON;
                    localStorage.userId = user.userId;
                    localStorage.username = user.username;

                    console.log(localStorage.userId);
                    console.log(localStorage.username);
                    console.log(localStorage.authUser);
                    console.log("Login Success");

                    window.location.href = "/Front_End/Views/index.html";
                }
                else {
                    //$("#msg").show();
                    //$("#msg").html(xhr.status + ":" + xhr.statusText);
                    $("#msg").html("<div class=\"alert alert-primary\" role=\"alert\">" + xhr.status + ":" + xhr.statusText + "</div>");
                }
            }
        });
    }

    $("#btnsignin").click(function () {
        loadLogin();
    });


});