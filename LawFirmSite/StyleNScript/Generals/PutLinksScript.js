function hmessagefadein(elem, id) {
    animate(document.getElementById(elem.id + "-hmessagediv"), id, "opacity", "1", 200, true, "block");
}
function hmessagefadeout(elem, id) {
    animate(document.getElementById(elem.id + "-hmessagediv"), id, "opacity", "0", 200, true, "none");
}

function putlinkss(where, idOff, buttonarray, horzAlign, horzOff, vertOff, vertAlign) {
    var buttondiv = document.createElement("div");
    if (horzAlign === "right") {
        buttondiv.style.right = horzOff;
    }
    else if (horzAlign === "left") {
        buttondiv.style.left = horzOff;
    }
    if (vertAlign === "bottom") {
        buttondiv.style.bottom = vertOff;
    }
    else {
        buttondiv.style.top = vertOff;
    }
    buttondiv.style.position = "absolute";

    where.appendChild(buttondiv);


    var horzAll = stoi(horzOff);

    for (var i = 0; i < buttonarray.length; i++) {
        var buttLink = document.createElement("a");
        buttLink.style.zIndex = 10;
        buttLink.id = "buttlink-" + (i + idOff);
        buttLink.className = buttonarray[i].class;
        buttLink.innerHTML = buttonarray[i].inner;

        if (buttonarray[i].address !== "") {
            var hrme = document.createAttribute("href");
            hrme.value = buttonarray[i].address;
            buttLink.setAttributeNode(hrme);
        }
        else {
            buttLink.removeAttribute("href");
            buttLink.className = buttLink.className + " hoverme";
        }
        
        if (horzAlign === "right") {
            buttondiv.insertBefore(buttLink, buttondiv.firstChild);
            if (i !== buttonarray.length - 1) {
                buttLink.style.marginLeft = "4px";
            }
            horzAll = horzAll + stoi(window.getComputedStyle(buttLink).getPropertyValue("width"));
        }
        else if (horzAlign === "left") {
            buttondiv.appendChild(buttLink);
            if (i !== buttonarray.length - 1) {
                buttLink.style.marginRight = "4px";
            }
        }

        if (buttonarray[i].onmousedown !== undefined && buttonarray[i].onmousedown !== null && buttonarray[i].onmousedown !== "") {
            buttLink.setAttribute("onmousedown", buttonarray[i].onmousedown);
        }

        buttLink.style.listStyleType = "hmessagediv-" + i;
        if (buttonarray[i].hmessage !== undefined && buttonarray[i].hmessage !== null && buttonarray[i].hmessage !== "") {
            var hmessagediv = document.createElement("div");
            hmessagediv.id = "buttlink-" + (i + idOff) + "-hmessagediv";
            hmessagediv.className = buttonarray[i].hmessage.class;
            if (vertAlign === "bottom") {
                hmessagediv.style.bottom = (parseInt(vertOff) + 40) + "px";
            }
            else {
                hmessagediv.style.top = (parseInt(vertOff) - 40) + "px";
            }
            hmessagediv.innerHTML = buttonarray[i].hmessage.message;
            hmessagediv.style.opacity = 0;
            hmessagediv.style.pointerEvents = "none";
            hmessagediv.style.position = "absolute";
            buttLink.setAttribute("onmouseover", "hmessagefadein(this," + (i + idOff + 500) + ")");
            buttLink.setAttribute("onmouseout", "hmessagefadeout(this," + (i + idOff + 500) + ")");
            where.appendChild(hmessagediv);
            if (horzAlign === "right") {
                hmessagediv.style.right = horzAll - parseInt(window.getComputedStyle(hmessagediv).getPropertyValue("width")) + "px";
                horzAll = horzAll + 8;
            }
            else {
                hmessagediv.style.left = horzAll + "px";

                horzAll = parseInt(window.getComputedStyle(buttondiv).getPropertyValue("width")) + 4;
            }
            hmessagediv.style.display = "none";
        }
    }
}