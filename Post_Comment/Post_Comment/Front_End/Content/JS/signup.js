$(document).ready(function () {
	var signup = function () {
		if ($("#username").val() != "" && $("#password").val() != "") {
		$.ajax({
			url: "http://localhost:59954/api/logins/",
			method: "POST",
			header: "Content-Type:application/json",
			data: {
				name: $("#username").val(),
				Password: $("#password").val()
			},
			complete: function (xmlhttp, status) {
				/*if ($("#username").val() != "" && $("#password").val() != "") {*/
					if (xmlhttp.status == 200) {
						$("#msg").html("<div class=\"alert alert-danger\" role=\"alert\">" + xmlhttp.status + ":" + xmlhttp.statusText + "</div>");
					}

					else {
						$("#msg").html("<div class=\"alert alert-danger\" role=\"alert\">" + xmlhttp.status + ":" + xmlhttp.statusText + "</div>");
					}
				/*}
				else {
					$("#msg").html("<div class=\"alert alert-danger\" role=\"alert\">Fill all the Fields</div>");
				}*/
			}
		});
		}
		else {
			$("#msg").html("<div class=\"alert alert-danger\" role=\"alert\">Fill all the Fields</div>");
		}
	}
	$("#btnsignup").click(function () {
		signup();
	});
});

