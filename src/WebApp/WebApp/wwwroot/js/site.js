// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//lists
let collection
let buttons

//vars
let size
let building
let name
let type

$("#Building").change(function() {
    //lists
    collection = $(".rooms")
    buttons = $(".roomButton")

    //vars
    size = $("#RoomSize")[0].value;
    building = $("#Building")[0].value
    name = $("#RoomName")[0].value
    type = $("#Type")[0].value

    hideButtons()
})

$("#RoomName").keyup(function() {
    //lists
    collection = $(".rooms")
    buttons = $(".roomButton")

    //vars
    size = $("#RoomSize")[0].value;
    building = $("#Building")[0].value
    name = $("#RoomName")[0].value
    type = $("#Type")[0].value

    hideButtons()
})

$("#RoomSize").keyup(function() {

    //lists
    collection = $(".rooms")
    buttons = $(".roomButton")

    //vars
    size = $("#RoomSize")[0].value;
    building = $("#Building")[0].value
    name = $("#RoomName")[0].value
    type = $("#Type")[0].value

    hideButtons()
})

$("#Type").change(function() {
    //lists
    collection = $(".rooms")
    buttons = $(".roomButton")

    //vars
    size = $("#RoomSize")[0].value;
    building = $("#Building")[0].value
    name = $("#RoomName")[0].value
    type = $("#Type")[0].value

    hideButtons()
})

function hideButtons() {
    for (var i = 0; i < collection.length; i++) {
        collection[i].hidden = false;
    }

    for (var i = 0; i < collection.length; i++) {
        if (checkB(building, collection[i]) || checkS(size, buttons[i]) || checkN(name, collection[i]) || checkT(type, buttons[i])) {
            collection[i].hidden = true;
        }
    }
}

//check the Building
function checkB(Building, elem) {
    let ret = false;
    if (elem.innerText.trim().charAt(0) != Building && Building != "all") {
        ret = true;
    }

    return ret;
}

//check the Size
function checkS(Size, elem) {
    let ret = false;
    let elemSize = parseInt(elem.attributes["roomsize"].value)

    if (elemSize < parseInt(Size) && parseInt(Size) > 0) {
        ret = true;
    }
    return ret;
}

//check the name
function checkN(Name, elem) {
    let ret = false;
    let elemName = elem.innerText.trim().substring(0, Name.length)
    if(elemName != Name && Name.length > 0) {
        ret = true;
    }
    return ret;
}

//check the type
function checkT(Type, elem) {
    let ret = false;
    if(elem.attributes["roomtype"].value != Type && Type != "all") {
        ret = true;
    }
    return ret;
}


$(".roomButton").click(function() {
    let buttonName = $(this)[0].innerText.trim()
    let frame = $("#iFrameContainer")[0]
    frame.innerHTML = "<iframe src=\"https://localhost:7270/home/RoomView/?name="+ buttonName + "\" height=\"600\" width=\"500\"></iframe>"
    //frame.innerHTML = "<iframe src=\"https://www.op.gg/\" height=\"200\" width=\"300\"></iframe>"
})

/*
function hideUselessButtons(building) {

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
*/

/*
function findRoom(name) {
    for (let i = 0; i < collection.length; i++) {
        if (collection[i].innerText.trim().substring(0, name.length) != name) {
            collection[i].hidden = true;
        }
        else {
            collection[i].hidden = false;
        }
    }
}
*/

/*
function findRoomSize(size) {
    let buttons = $(".roomButton")
    for (let i = 0; i < collection.length; i++) {
        if (parseInt(buttons[i].attributes["roomsize"].value) < size) {
            collection[i].hidden = true;
        }
        else {
            collection[i].hidden = false;
        }
    }
}
*/

