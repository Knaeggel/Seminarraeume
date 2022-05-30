// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#Building").change(function() {
    hideUselessButtons($("#Building")[0].value)
})

function hideUselessButtons(building) {
    let collection = $(".rooms")

    if (building == "all") {
        for (var i = 0; i < collection.length; i++) {
            collection[i].hidden = false;
        }
    }
    else {
        for (var i = 0; i < collection.length; i++) {
            let y = collection[i].innerText.charAt(0)
            if (collection[i].innerText.trim().charAt(0) == building) {
                collection[i].hidden = false;
            }
            else {
                collection[i].hidden = true;
            }
        }
    }
}

$(".roomButton").click(function() {
    let buttonName = $(this)[0].innerText.trim()
    let frame = $("#iFrameContainer")[0]
    frame.innerHTML = "<iframe src=\"https://localhost:7270/home/RoomView/?name="+ buttonName + "\" height=\"600\" width=\"500\"></iframe>"
    //frame.innerHTML = "<iframe src=\"https://www.op.gg/\" height=\"200\" width=\"300\"></iframe>"
})