function stoi(str) {
    var result = 0;
    str = str + "";

    for (var i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) <= 57 && str.charCodeAt(i) >= 48) {
            result = result + str.charCodeAt(i) - 48;
            result = result * 10;
        }
        else {
            return result / 10;
        }
    }
    return result / 10;
}

function stof(str) {
    var result = 0.0;
    str = str + "";
    
    var i = 0;
    for (; i < str.length; i++) {
        if (str.charCodeAt(i) <= 57 && str.charCodeAt(i) >= 48) {
            result = result + str.charCodeAt(i) - 48;
            result = result * 10;
        }
        else {
            break;
        }
    }
    result = result / 10;
    if (str.charCodeAt(i) === 46) {
        i++;
        for (var a = 10; i < str.length; i++) {
            if (str.charCodeAt(i) <= 57 && str.charCodeAt(i) >= 48) {
                result = result + (str.charCodeAt(i) - 48) / a;
            }
            else {
                return result;
            }
            a = a * 10;
        }
    }
    return result;
}

function findidPos(Aarray, id) {
    for (var pos = 0; pos < Aarray.length; pos++) {
        if (Aarray[pos].id === id) {
            return pos;
        }
    }
    return -1;
}

var nums = "0123456789";

function getValue(elem, proprt, str) {
    var numobj = { num: 0.0, type: "" };


    for (var i = str.length - 1; i !== -1; i--) {
        if (-1 !== nums.indexOf(str[i])) {
            break;
        }
        numobj.type = str[i] + numobj.type;
    }

    numobj.num = parseFloat(str);

    if (numobj.type === "%%") {
        if (proprt.indexOf("left") !== -1 || proprt.indexOf("right") !== -1) {
            proprt = "width";
        }
        //var pa = elem.parentNode;
        //((elem.offsetWidth / pa.offsetWidth) * 100).toFixed(2) + '%';
        numobj.num = numobj.num * 100 / parseFloat(window.getComputedStyle(elem.parentNode).getPropertyValue(proprt));
        numobj.type = "%";
    }

    return numobj;
}

var anims = [];

function animate(elem, id, proprt, to, tooksMs, canbeCanceled, displayme) {
    var pos = 0;
    var tlen = anims.length;
    for (; pos < tlen; pos++) {
        if (anims[pos].id === id) {
            if (anims[pos].cancelable) {
                clearInterval(anims[pos].time);
                break;
            }
            return elem;
        }
    }
    var from = parseFloat(window.getComputedStyle(elem).getPropertyValue(proprt));
    var desObj = getValue(elem, proprt, String(to));

    if (desObj.type === "%") {
        from = getValue(elem, proprt, from + "%%").num;
    }
    
    to = desObj.num;
    

    var dif = to - from;
    if (desObj.type === "%" || desObj.type === "") {
        dif = dif * 100;
    }

    var intervals = 0;
    if (Math.abs(dif) < tooksMs) {
        intervals = tooksMs / Math.abs(dif);
        if (intervals < 16) {
            intervals = 16;
        }
        dif = dif * intervals / tooksMs;
    }
    else {
        intervals = 16;
        if (tooksMs < 16) {
            tooksMs = 16;
        }
        dif = dif * 16 / tooksMs;
    }
    if (desObj.type === "%" || desObj.type === "") {
        dif = dif / 100;
    }

    if (findidPos(anims, id) === -1) {
        anims.push({ id: id, time: 0, cancelable: canbeCanceled });
    }

    if (displayme !== undefined && displayme !== "none" && displayme !== "") {
        elem.style.display = displayme;
    }

    var t_o = anims[findidPos(anims, id)].time = setInterval(function () {
        from = from + dif;

        if ((dif < 0 && to >= from) || (dif > 0 && to <= from)) {

            clearInterval(t_o);
            anims.splice(findidPos(anims, id), 1);

            elem.style.setProperty(proprt, desObj.num + desObj.type);

            if (displayme !== undefined && displayme === "none") {
                elem.style.setProperty("display", displayme);
            }

            return;
        }
        
        elem.style.setProperty(proprt, from + desObj.type);

    }, intervals);
    return elem;
}

function putCrumbs(puthere, nameNUrlarray) {
    var cdiv = document.createElement("div");
    cdiv.className = "crumbs";
    var i = 0;
    for (; i < nameNUrlarray.length - 1; i++) {
        var cLink = document.createElement("a");
        cLink.innerHTML = nameNUrlarray[i].page;
        cLink.className = "crumbsLink";
        var hrme = document.createAttribute("href");
        hrme.value = nameNUrlarray[i].link;
        cLink.setAttributeNode(hrme);

        var csep = document.createElement("label");
        csep.innerHTML = "/";
        csep.className = "mx-2";

        cdiv.appendChild(cLink);
        cdiv.appendChild(csep);
    }

    var cLLink = document.createElement("a");
    cLLink.innerHTML = nameNUrlarray[i].page;
    cLLink.className = "crumbsLink";
    var hLrme = document.createAttribute("href");
    hLrme.value = nameNUrlarray[nameNUrlarray.length - 1].link;
    cLLink.setAttributeNode(hLrme);

    cdiv.appendChild(cLLink);

    puthere.appendChild(cdiv);
}

function getValueFromDic(dic, value) {
    var sectionSeparator = "-7257a42-21g3sdf21-";
    var pos = dic.indexOf(sectionSeparator + value + sectionSeparator);
    if (pos !== -1) {
        pos += sectionSeparator.length * 2 + value.length;
        return dic.substr(pos, dic.indexOf(sectionSeparator + value + sectionSeparator, pos) - pos);
    }
    else {
        if (value === "Admin") {
            return "Control Panel";
        }
        else {
            return value;
        }
    }
}

function getControllerName() {
    var pathname = window.location.pathname;
    if (pathname.indexOf("/", 1) !== -1) {
        return pathname.substr(1, pathname.indexOf("/", 1) - 1);
    }
    else {
        return pathname.substr(1);
    }
}

function replacethissWthat(str, thiss, that) {
    var itr = str.indexOf(thiss);
    while (itr !== -1) {
        str = str.substring(0, itr) + that + str.substring(itr + thiss.length);
        itr = str.indexOf(thiss);
    }
    return str;
}


function nameWinner(langdic) {
    var getnameselems = document.getElementsByClassName("namemebyinner");
    for (var i = 0; i < getnameselems.length; i++) {
        getnameselems[i].innerHTML = getValueFromDic(langdic, getnameselems[i].innerHTML);
    }
}

function nameWid(langdic) {
    var getnameselems = document.getElementsByClassName("namemebyid");
    for (var i = 0; i < getnameselems.length; i++) {
        getnameselems[i].innerHTML = getValueFromDic(langdic, getnameselems[i].id);
    }
}


function namebuttonsWValues(langdic) {
    var getnameselems = document.getElementsByTagName("button");
    for (var i = 0; i < getnameselems.length; i++) {
        getnameselems[i].value = getValueFromDic(langdic, getnameselems[i].value);
    }
}

function setHeighttoElems(div, elemArray, plusthis = 0) {
    var elemHeight = 0;
    for (var i = 0; i < elemArray.length; i++) {
        var posibleelemHeight = parseFloat(window.getComputedStyle(elemArray[i]).getPropertyValue("height"));
        if (elemHeight < posibleelemHeight) {
            elemHeight = posibleelemHeight;
        }
    }
    div.style.setProperty("height", elemHeight + parseInt(plusthis) + "px");
}

function getInside(str) {
    var result = "";
    for (var i = 0; i < str.length; i++) {
        if (str[i] === "<") {
            for (; str[i] !== ">"; i++) { }
            continue;
        }
        result = result + str[i];
    }
    return result;
}