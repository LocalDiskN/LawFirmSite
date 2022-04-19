function getDateFormat(format) {
    format = format.toLowerCase();
    var result = "";
    var ddone = false;
    var mdone = false;
    var ydone = false;
    for (var i = 0; i < format.length; i++) {
        if (!ddone && format[i] === "d") {
            result = result + "dd";
            ddone = true;
            if (!mdone || !ydone) {
                result = result + "/";
            }
            else {
                break;
            }
        }
        if (!mdone && format[i] === "m") {
            result = result + "mm";
            mdone = true;
            if (!ddone || !ydone) {
                result = result + "/";
            }
            else {
                break;
            }
        }
        if (!ydone && format[i] === "y") {
            result = result + "yyyy";
            ydone = true;
            if (!mdone || !ddone) {
                result = result + "/";
            }
            else {
                break;
            }
        }
    }
    if (!ddone || !mdone || !ydone) {
        result = "dd/mm/yyyy";
    }
    return result;
}

function contentify(TAarray, off) {
    var sectionSeparator = "-7257a42-21g3sdf21-";
    var result = "";

    for (var i = 2; i < TAarray[off].length; i++) {
        if (TAarray[off][i].key === "DateFormat") {
            TAarray[off][i].TA.value = getDateFormat(TAarray[off][i].TA.value);
        }
        result = result + sectionSeparator + TAarray[off][i].key + sectionSeparator + TAarray[off][i].TA.value + sectionSeparator + TAarray[off][i].key + sectionSeparator;
    }
    return result;
}

function putLanguagesEditArray(languages, wheress, idOff) {
    var result = [[]];
    var keySeparator = "/77334sa524/453f8675/";
    
    for (var i = 1; i < languages.length; i++) {
        result.push([]);
        var maindiv = document.createElement("div");
        wheress[i - 1].appendChild(maindiv);

        var cmaindiv = document.createElement("div");
        cmaindiv.className = "wqeqwe";
        maindiv.appendChild(cmaindiv);

        {
            var infmediv = document.createElement("div");
            infmediv.className = "fsdfsdfs";
            cmaindiv.appendChild(infmediv);

            var infhead = document.createElement("div");
            infhead.className = "infolabel";
            infhead.innerHTML = getValueFromDic(crumbstr.Content, "Language");
            infmediv.appendChild(infhead);

            var incontemp = document.createElement("div");
            incontemp.className = "infoTADiv";
            infmediv.appendChild(incontemp);

            result[i - 1].push({ key: "Language", TA: putHTMLEditor(incontemp, idOff * 900 * i + a, { x: "100%", y: "30px", ymax: "30px", ymin: "30px" }, [], ["none"], getValueFromDic(languages[i].Content, languages[i].Title)) });

            var infmediv2 = document.createElement("div");
            infmediv2.className = "fsdfsdfs";
            cmaindiv.appendChild(infmediv2);

            var infhead2 = document.createElement("div");
            infhead2.className = "infolabel";
            infhead2.innerHTML = getValueFromDic(crumbstr.Content, "Abbreviation");
            infmediv2.appendChild(infhead2);

            var incontemp2 = document.createElement("div");
            incontemp2.className = "infoTADiv";
            infmediv2.appendChild(incontemp2);

            result[i - 1].push({ key: "Abbreviation", TA: putHTMLEditor(incontemp2, idOff * 900 * i + a, { x: "100%", y: "30px", ymax: "30px", ymin: "30px" }, [], ["none"], getValueFromDic(languages[i].Content, languages[i].Abbreviation)) });
        }

        var backitr = 0;
        var keyitr = languages[0].Content.indexOf(keySeparator, backitr);
        for (var a = 0; keyitr !== -1; a++) {
            var infmediv3 = document.createElement("div");
            cmaindiv.appendChild(infmediv3);

            var infhead3 = document.createElement("div");
            infhead3.className = "infolabel";
            infhead3.innerHTML = languages[0].Content.substr(backitr, keyitr - backitr);
            infmediv3.appendChild(infhead3);

            var incontemp3 = document.createElement("div");
            incontemp3.className = "infoTADiv";
            infmediv3.appendChild(incontemp3);

            backitr = keyitr + keySeparator.length;
            keyitr = languages[0].Content.indexOf(keySeparator, backitr);

            result[i - 1].push({ key: infhead3.innerHTML, TA: putHTMLEditor(incontemp3, idOff * 900 * i + a, { x: "100%", y: "30px", ymax: "30px", ymin: "30px" }, [], ["none"], getValueFromDic(languages[i].Content, infhead3.innerHTML)) });

            if (infhead3.innerHTML === "DateFormat") {
                infhead3.innerHTML = getValueFromDic(crumbstr.Content, "DateTimeFormat");
            }
        }

        var saveButt = document.createElement("button");
        saveButt.id = "saveTranslation-" + idOff + "-" + i;
        saveButt.innerHTML = "Save";
        saveButt.className = "namemebyinner buttonLink bluebuttonLinkhollow hoverme";
        saveButt.style.marginLeft = "45%";
        saveButt.style.fontSize = "24px";
        saveButt.style.textAlign = "center";

        maindiv.appendChild(saveButt);

    }

    return result;
}