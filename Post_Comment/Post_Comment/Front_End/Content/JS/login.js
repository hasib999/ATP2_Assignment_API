$(document).ready(function () {
	var login = function () {

		$.ajax({
			url: "http://localhost:59954/api/posts/",
			method: "GET",
			headers: {
				Authorization: "Basic " + btoa($("#username").val() + ":" + $("#password").val())
			},
			complete: function (xmlhttp, status) {
				if ($("#username").val() != "" && $("#password").val() != "") {
					if (xmlhttp.status == 200) {
						$("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText);
						console.log("okk");

						
						$.session.set('user', $("#username").val());
						$.session.set('pass', $("#password").val());

						window.location.href = "/Front_End/Views/index.html";
					}

					else {
						$("#msg").html("<div class=\"alert alert-danger\" role=\"alert\">" + xmlhttp.status + ":" + xmlhttp.statusText + "</div>");
						
						/*$("#msg").html(xmlhttp.status + ":" + xmlhttp.statusText);*/
					}
				}
				else {
					
					$("#msg").html("<div class=\"alert alert-danger\" role=\"alert\">Fill all the Fields</div>");
				}
			}
		});
	}

	$("#btnsignin").click(function () {
		login();
	});


});