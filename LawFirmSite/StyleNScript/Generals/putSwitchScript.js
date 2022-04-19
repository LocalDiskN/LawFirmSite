function getSwitchState(switchElem) {
    if (switchElem.className.indexOf("on") !== -1) {
        return true;
    }
    else {
        return false;
    }
}

function putSwitch(where, idOff, width, height, onOff = false, shape = "oval", onColor = "green", offColor = "lightgray", switchSpeed = 100, switchColor = "white") {
    maindiv = document.createElement("div");
    maindiv.style.cursor = "pointer";
    maindiv.style.width = width;
    maindiv.style.height = height;

    relcondiv = document.createElement("div");
    relcondiv.style.position = "relative";
    relcondiv.style.pointerEvents = "none";

    leftback = document.createElement("div");
    leftback.style.position = "absolute";
    leftback.style.border = "1px solid gray";
    leftback.style.borderRight = "0px solid gray";
    leftback.style.width = height;
    leftback.style.height = height;
    leftback.id = "switchBackLeft-" + idOff;
    leftback.style.pointerEvents = "none";

    var numWidth = parseFloat(width);
    var numHeight = parseFloat(height);

    rightback = document.createElement("div");
    rightback.style.position = "absolute";
    rightback.style.border = "1px solid gray";
    rightback.style.borderLeft = "0px solid gray";
    rightback.style.width = height;
    rightback.style.height = height;
    rightback.style.left = numWidth - numHeight + "px";
    rightback.id = "switchBackRigth-" + idOff;
    rightback.style.pointerEvents = "none";


    centerback = document.createElement("div");
    centerback.style.position = "absolute";
    centerback.style.borderTop = "1px solid gray";
    centerback.style.borderBottom = "1px solid gray";
    centerback.style.width = numWidth - numHeight + "px";
    centerback.style.height = height;
    centerback.style.left = numHeight / 2 + "px";
    centerback.id = "switchBackCenter-" + idOff;
    rightback.style.pointerEvents = "none";
    

    stiwhcbutt = document.createElement("div");
    stiwhcbutt.style.position = "absolute";
    stiwhcbutt.style.backgroundColor = switchColor;
    stiwhcbutt.style.width = height;
    stiwhcbutt.style.height = height;
    stiwhcbutt.id = "switchButt-" + idOff;
    stiwhcbutt.style.pointerEvents = "none";

    if (onOff) {
        maindiv.className = "on";
        leftback.style.backgroundColor = onColor;
        rightback.style.backgroundColor = onColor;
        centerback.style.backgroundColor = onColor;
        stiwhcbutt.style.left = numWidth - numHeight + "px";
    }
    else {
        maindiv.className = "off";
        leftback.style.backgroundColor = offColor;
        rightback.style.backgroundColor = offColor;
        centerback.style.backgroundColor = offColor;
    }

    if (shape === "oval") {
        leftback.style.borderRadius = "50%";
        rightback.style.borderRadius = "50%";
        stiwhcbutt.style.borderRadius = "50%";
    }
    relcondiv.appendChild(leftback);
    relcondiv.appendChild(rightback);
    relcondiv.appendChild(centerback);
    relcondiv.appendChild(stiwhcbutt);

    maindiv.appendChild(relcondiv);
    where.appendChild(maindiv);

    maindiv.addEventListener("mousedown", function (event) {
        if (event.target.className.indexOf("on") !== -1) {
            document.getElementById("switchBackLeft-" + idOff).style.backgroundColor = offColor;
            document.getElementById("switchBackRigth-" + idOff).style.backgroundColor = offColor;
            document.getElementById("switchBackCenter-" + idOff).style.backgroundColor = offColor;
            event.target.className = "off";
            //document.getElementById("switchButt-" + idOff).style.left = 0 + "px";
            animate(document.getElementById("switchButt-" + idOff), idOff, "left", "0px", switchSpeed, true);
        }
        else {
            document.getElementById("switchBackLeft-" + idOff).style.backgroundColor = onColor;
            document.getElementById("switchBackRigth-" + idOff).style.backgroundColor = onColor;
            document.getElementById("switchBackCenter-" + idOff).style.backgroundColor = onColor;
            event.target.className = "on";
            animate(document.getElementById("switchButt-" + idOff), idOff, "left", numWidth - numHeight + "px", switchSpeed, true);
            //document.getElementById("switchButt-" + idOff).style.left = numWidth - numHeight + "px";
        }
    });

    return maindiv;
}