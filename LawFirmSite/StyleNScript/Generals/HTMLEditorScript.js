function getTagpos(str, curpos) {
    for (var i = curpos; i < str.length; i++) {
        if (str[i] === "<") {
            break;
        }
        if (str[i] === ">") {
            var tagme = ">";
            for (i = i - 1; i !== -1; i--) {
                if (str[i] === "/") {
                    var temppos = str.lastIndexOf("<" + tagme, i - 1);
                    var tempmepos2 = str.lastIndexOf("</" + tagme, i - 1);
                    var skipmany = -1;
                    while (temppos < tempmepos2) {
                        skipmany++;
                        tempmepos2 = str.lastIndexOf("</" + tagme, tempmepos2 - 1);
                    }
                    while (skipmany !== 0) {
                        temppos = str.lastIndexOf("<" + tagme, temppos - 1);
                        skipmany--;
                    }
                    return { tagtaglength: tagme.length + 1, start: temppos, end: i - 1 };
                }
                if (str[i] === "<") {
                    var temppos3 = str.indexOf("</" + tagme, i + 1);
                    var tempmepos23 = str.indexOf("<" + tagme, i + 1);
                    var skipmany3 = 0;
                    while (temppos3 > tempmepos23) {
                        skipmany3++;
                        tempmepos23 = str.indexOf("<" + tagme, tempmepos23 + 1);
                        if (tempmepos23 === -1) {
                            break;
                        }
                    }
                    while (skipmany3 !== 0) {
                        temppos3 = str.indexOf("</" + tagme, temppos3 + 1);
                        skipmany3--;
                    }
                    return { tagtaglength: tagme.length + 1, start: i, end: temppos3 };
                }
                tagme = str[i] + tagme;
            }
        }
    }
}

function InserttoSelection(textComponent, tofront, toend) {
    if (textComponent.selectionStart !== undefined) {// Standards Compliant Version

        var startPos = textComponent.selectionStart;
        var endPos = textComponent.selectionEnd;

        if (startPos === endPos) {
            var tagsmeme = getTagpos(textComponent.value, startPos);
            if (tagsmeme !== undefined && tagsmeme !== -1) {
                textComponent.value = textComponent.value.substr(0, tagsmeme.start) + tofront + textComponent.value.substr(tagsmeme.start + tagsmeme.tagtaglength, tagsmeme.end - (tagsmeme.start + tagsmeme.tagtaglength)) + toend + textComponent.value.substr(tagsmeme.end + tagsmeme.tagtaglength + 1);

            }
            else {
                textComponent.value = textComponent.value.substring(0, startPos) + tofront + textComponent.value.substring(startPos, endPos) + toend + textComponent.value.substring(endPos);
            }
        }
        else {
            for (var i = startPos; i <= endPos; i++) {
                var tagsme = getTagpos(textComponent.value, i);
                if (tagsme !== undefined && tagsme !== -1) {
                    textComponent.value = textComponent.value.substr(0, tagsme.start) + textComponent.value.substr(tagsme.start + tagsme.tagtaglength, tagsme.end - (tagsme.start + tagsme.tagtaglength)) + textComponent.value.substr(tagsme.end + tagsme.tagtaglength + 1);
                    if (tagsme.start < startPos) {
                        startPos = startPos - (startPos - tagsme.start < tagsme.tagtaglength ? startPos - tagsme.start : tagsme.tagtaglength);
                    }
                    if (tagsme.end < startPos) {
                        startPos = startPos - tagsme.end;
                    }
                    if (tagsme.start < endPos) {
                        endPos = endPos - (endPos - tagsme.start < tagsme.tagtaglength ? endPos - tagsme.start : tagsme.tagtaglength);
                    }
                    if (tagsme.end < endPos) {
                        endPos = endPos - (endPos - tagsme.end < tagsme.tagtaglength + 1 ? endPos - tagsme.end : tagsme.tagtaglength + 1);
                    }
                }
            }


            textComponent.value = textComponent.value.substring(0, startPos) + tofront + textComponent.value.substring(startPos, endPos) + toend + textComponent.value.substring(endPos);
        }

        textComponent.setSelectionRange(endPos + tofront.length, endPos + tofront.length);
    }
    //else if (document.selection !== undefined) {// IE Version
    //    textComponent.focus();
    //    var sel = document.selection.createRange();
    //    selectedText = sel.text;
    //}
}

function boldButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<b>", "</b>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function italicButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<i>", "</i>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function subButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<sub>", "</sub>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function supButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<sup>", "</sup>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function markButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<mark>", "</mark>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function smallButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<small>", "</small>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function lineoverButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<del>", "</del>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

function lineunderButtonFunk(textmeid, showdivids) {
    var textarea = document.getElementById(textmeid);
    InserttoSelection(textarea, "<ins>", "</ins>");
    for (var i = 0; i < showdivids.length; i++) {
        document.getElementById(showdivids[i]).innerHTML = textarea.value;
    }
}

var badtouch = true;
var textmelength = -1;
var badplace = -1;

function putHTMLEditor(where, idOff, sizeXY, prevDivs, whichbuttons = ["all"], defValue, issafe, maxlength) {
    var maindiv = document.createElement("div");
    maindiv.style.width = "100%";

    var buttonsdiv = document.createElement("div");
    buttonsdiv.style.width = "100%";
    buttonsdiv.style.height = "24px";
    buttonsdiv.style.position = "relative";
    maindiv.appendChild(buttonsdiv);

    var textme = document.createElement("textarea");

    if (sizeXY.x !== undefined) {
        textme.style.width = sizeXY.x;
    }
    if (sizeXY.xmax !== undefined) {
        textme.style.maxWidth = sizeXY.xmax;
    }
    if (sizeXY.xmin !== undefined) {
        textme.style.minWidth = sizeXY.xmin;
    }
    if (sizeXY.y !== undefined) {
        textme.style.height = sizeXY.y;
    }
    if (sizeXY.ymax !== undefined) {
        textme.style.maxHeight = sizeXY.ymax;
    }
    if (sizeXY.ymin !== undefined) {
        textme.style.minHeight = sizeXY.ymin;
    }

    if (maxlength !== undefined) {
        textme.maxLength = maxlength;
    }

    textme.id = "htmleditarea-" + idOff;
    if (issafe !== undefined || issafe === true) {
        textme.className = "safeTA";
        textme.addEventListener("keydown", function (e) {
            var keynum;
            if (window.event) { // IE                    
                keynum = e.keyCode;
            } else if (e.which) { // Netscape/Firefox/Opera                   
                keynum = e.which;
            }
            var thistexta = document.getElementById("htmleditarea-" + idOff);
            var curbad = getTagpos(thistexta.value, thistexta.selectionStart);
            var befbad = getTagpos(thistexta.value, thistexta.selectionStart - 1);
            if (curbad !== undefined) {
                console.log("hello");
                badtouch = true;
                badplace = thistexta.selectionStart;
            }
            else if (keynum === 8) {
                if (curbad !== undefined) {

                    badtouch = true;
                    badplace = thistexta.selectionStart;
                }
                else if (befbad !== undefined) {

                    badtouch = true;
                    badplace = thistexta.selectionStart;
                }
                else if (thistexta.value[thistexta.selectionStart - 1] === ";") {
                    var goods = ["&quot;", "&#x27;", "&amp;", "&#x2F;", "&lt;", "&gt;"];
                    badtouch = false;
                    for (var i = 0; i < goods.length; i++) {
                        badplace = thistexta.value.lastIndexOf(goods[i], thistexta.selectionStart);
                        if (badplace !== -1 && (badplace - thistexta.selectionStart) <= 6) {
                            console.log(badplace);
                            console.log(thistexta.selectionStart);
                            badtouch = true;
                            break;
                        }
                        else {
                            badplace = -1;
                        }
                    }
                }
            }
            else {
                badtouch = false;
            }
            textmelength = thistexta.value.length;

        });
    }
    //if ([34, 38, 39, 47, 60, 62, 97].indexOf(keynum) !== -1) {
    //    for (var i = 0; i !== -1; i--) {

    //    }

    //}
    textme.addEventListener("keyup", function () {
        var thistexta = document.getElementById("htmleditarea-" + idOff);
        for (var i = 0; i < prevDivs.length; i++) {
            if (thistexta.className.indexOf("safeTA") !== -1 && thistexta.className.indexOf("unsafeTA") === -1) {
                var bads = "\"'&/<>";
                var delpos = bads.indexOf(thistexta.value[thistexta.selectionEnd - 1]);
                if (issafe === undefined || issafe) {
                    if (badtouch && textmelength !== thistexta.value.length) {

                        var endPos = thistexta.selectionEnd;

                        thistexta.value = thistexta.value.substr(0, endPos - (endPos - badplace)) + thistexta.value.substr(endPos);
                        thistexta.selectionStart = thistexta.selectionEnd = endPos - 1;
                    }
                    if (delpos !== -1 && textmelength < thistexta.value.length) {
                        var aai = thistexta.selectionEnd - 2;
                        for (; aai !== -1; aai--) {
                            if (thistexta.value[aai] !== bads[delpos]) {
                                aai++;
                                break;
                            }
                        }
                        var goods = ["&quot;", "&#x27;", "&amp;", "&#x2F;", "&lt;", "&gt;"];
                        for (var endme = thistexta.selectionEnd; aai < endme; aai = aai + goods[delpos].length) {
                            thistexta.value = thistexta.value.substr(0, aai) + goods[delpos] + thistexta.value.substr(aai + 1);
                        }
                    }
                }
            }
            
            prevDivs[i].innerHTML = thistexta.value;
        }
    });
    if (defValue !== undefined && defValue !== null && defValue !== "") {
        textme.defaultValue = defValue;
        for (var i = 0; i < prevDivs.length; i++) {
            prevDivs[i].innerHTML = defValue;
        }
    }

    maindiv.appendChild(textme);

    where.appendChild(maindiv);

    if (whichbuttons[0] === "all") {

        var predivstr = "[";
        if (prevDivs.length > 0) {
            for (i = 0; i < prevDivs.length - 1; i++) {
                predivstr = predivstr + "'" + prevDivs[i].id + "',";
            }
            predivstr = predivstr + "'" + prevDivs[i].id + "']";
        }
        else {
            predivstr = "[]";
        }

        var buttonlinks = [
            { inner: '<i class="fas fa-bold"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Bold"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "boldButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-italic"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Italic"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "italicButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-highlighter"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Mark"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "markButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-unlink"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "LineOver"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "lineoverButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-underline"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "LineUnder"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "lineunderButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-superscript"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Superscript"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "supButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-subscript"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Subscript"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "subButtonFunk('" + textme.id + "'," + predivstr + ")" },
            { inner: '<i class="fas fa-search-minus"></i>', class: "buttonLink", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Small"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "smallButtonFunk('" + textme.id + "'," + predivstr + ")" }
        ];
        putlinkss(buttonsdiv, idOff, buttonlinks, "left", "0px", "0px");
    }
    return textme;
}