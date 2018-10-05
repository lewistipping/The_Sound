var positions = ["00", "01", "02", "10", "11", "12", "20", "21"];
var tiles = document.getElementsByClassName("tile");

function select(id) {
    var element = document.getElementById(id);
    var newElement;

    var row = parseInt(id.charAt(3) - '0');
    var col = parseInt(id.charAt(4) - '0');

    if (document.getElementById("img" + (row + 1) + col) !== null) {
        newElement = document.getElementById("img" + (row + 1) + col);
        if (newElement.src.match("imgBlank")) {
            var temp = element.src;
            element.src = newElement.src;
            newElement.src = temp;
            over();
            return;
        }
    }

    if (document.getElementById("img" + (row - 1) + col) !== null) {
        newElement = document.getElementById("img" + (row - 1) + col);
        if (newElement.src.match("imgBlank")) {
            var temp = element.src;
            element.src = newElement.src;
            newElement.src = temp;
            over();
            return;
        }
    }

    if (document.getElementById("img" + row + (col + 1)) !== null) {
        newElement = document.getElementById("img" + row + (col + 1));
        if (newElement.src.match("imgBlank")) {
            var temp = element.src;
            element.src = newElement.src;
            newElement.src = temp;
            over();
            return;
        }
    }

    if (document.getElementById("img" + row + (col - 1)) !== null) {
        newElement = document.getElementById("img" + row + (col - 1));
        if (newElement.src.match("imgBlank")) {
            var temp = element.src;
            element.src = newElement.src;
            newElement.src = temp;
            over();
            return;
        }
    }
}

function over() {
    for (i = 0; i < 8; i++) {
        if (tiles[i].src.match("img" + positions[i]) === null) {
            return;
        }
    }

    if (tiles[8].src.match("imgBlank") !== null) {
        var finalTile = tiles[8];
        finalTile.src = "../Files/Exclusive/Puzzle/img22.jpg";
        PageMethods.GetSong(onSuccess, onError);
    }
}

function onSuccess(result) {
    window.location = result;
}

function onError(result) {
    alert(result);
}