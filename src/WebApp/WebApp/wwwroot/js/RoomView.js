//this is the JavaScript file vor RoomView.cshtml

$(".btncheck").click(function () {
	if (this.attributes["bookable"].value == "true") {
		if (this.attributes["ischecked"].value == "false") {
			this.attributes["ischecked"].value = "true";
			var theClass = this.classList[3]

			var ret;
			switch (theClass) {
				case "btn-outline-primary":
					this.classList.remove("btn-outline-primary")
					ret = "btn-primary";
					break;

				case "btn-outline-success":
					this.classList.remove("btn-outline-success")
					ret = "btn-success";
					break;

				case "btn-outline-danger":
					this.classList.remove("btn-outline-danger")
					ret = "btn-danger";
					break;

				case "btn-outline-warning":
					this.classList.remove("btn-outline-warning")
					ret = "btn-warning";
					break;

				default:
					ret = "";
					break;
			}

			this.classList.add(ret)
		}
		else {
			this.attributes["ischecked"].value = "false";
			var theClass = this.classList[3]

			var ret;
			switch (theClass) {
				case "btn-primary":
					this.classList.remove("btn-primary")
					ret = "btn-outline-primary";
					break;
					
				case "btn-success":
					this.classList.remove("btn-success")
					ret = "btn-outline-success";
					break;

				case "btn-danger":
					this.classList.remove("btn-danger")
					ret = "btn-outline-danger";
					break;

				case "btn-warning":
					this.classList.remove("btn-warning")
					ret = "btn-outline-warning";
					break;

				default:
					ret = "";
					break;
			}

			this.classList.add(ret)
		}
	}
})