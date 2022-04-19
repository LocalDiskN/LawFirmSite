var changedif = 2;
function fadein(elem, id)
{
    animate(elem.parentElement.childNodes[2], id + 200, "width", "101%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "28px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "101%", 300, true);
    
    //animate(elem.parentElement, id + 400, "margin-right", "1%", 300, true);
    animate(elem, id, "opacity", "1", 300, true);
}

function fadeout(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "100%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "24px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "100%", 300, true);
    //animate(elem.parentElement, id + 400, "margin-right", "0.7%", 300, true);
    animate(elem, id, "opacity", "0", 300, true);
}

function oddfadein(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "101%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "28px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "101%", 300, true);
    //animate(elem, id + 200, "width", "101%", 300, true);
    animate(elem, id, "opacity", "1", 300, true);
}

function oddfadeout(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "100%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "24px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "100%", 300, true);
    //animate(elem, id + 200, "width", "100%", 300, true);
    animate(elem, id, "opacity", "0", 300, true);
}

function putPractices(where, practiceArray) {

    var loopcount = practiceArray.length % 2 === 0 ? practiceArray.length : practiceArray.length - 1;

    var buttonlinks = [
        { inner: '<i class="fas fa-times"></i>', class: "buttonLink redbuttonLinkhollow", address: "#", hmessage: { message: getValueFromDic(crumbstr.Content, "Delete"), class: "buttonLink redbuttonLinkhollow" }, onmousedown: "" },
        { inner: '<i class="far fa-edit"></i>', class: "buttonLink bluebuttonLinkhollow", address: "#", hmessage: { message: getValueFromDic(crumbstr.Content, "Edit"), class: "buttonLink bluebuttonLinkhollow" }, onmousedown: "" }
    ];

    var sendarray = [];

    for (var i = 0; i < loopcount; i++) {

        var divLink = document.createElement("a");
        divLink.id = "divmelinkssc-" + i;
        divLink.style.opacity = 0;
        divLink.className = "linkCssme";
        var hrme = document.createAttribute("href");
        hrme.value = "/Practices/Practice/?id=" + practiceArray[i].idme;
        divLink.setAttributeNode(hrme);

        var stockimg = document.createElement("img");
        stockimg.className = "practiceimg";
        var srcme = document.createAttribute("src");
        srcme.value = practiceArray[i].ImgUrl;
        stockimg.setAttributeNode(srcme);
        divLink.appendChild(stockimg);

        var stockcaption = document.createElement("h4");
        stockcaption.id = "captionmepractice-" + i;
        stockcaption.className = "practices-img-header";
        stockcaption.innerHTML = practiceArray[i].Title;
        divLink.appendChild(stockcaption);

        var imgDivd = document.createElement("div");
        imgDivd.className = "practices-Absolute-imgDiv";
        imgDivd.setAttribute("onmouseover", "fadein(this," + (i + 20000) + ")");
        imgDivd.setAttribute("onmouseout", "fadeout(this," + (i + 20000) + ")");
        divLink.appendChild(imgDivd);

        where.appendChild(divLink);
        sendarray.push([divLink, stockimg, stockcaption]);

        buttonlinks[0].onmousedown = "asyncDelete('/Practices/Delete/',  { NameOrid: '" + practiceArray[i].idme + "', LangAbr: '" + crumbstr.Abbreviation + "'} , 'divmelinkssc-" + i + "')";
        buttonlinks[1].address = "/Practices/Edit/?id=" + practiceArray[i].idme;

        putlinkss(divLink, 700 + (i * 3), buttonlinks, "right", "0px", "0px");
    }

    if (loopcount !== practiceArray.length) {
        var divLink2 = document.createElement("a");
        divLink2.id = "divmelinkssc-" + loopcount;
        divLink2.style.opacity = 0;
        divLink2.className = "link-Last-Cssme";
        var hrme2 = document.createAttribute("href");
        hrme2.value = "/Practices/Practice/?id=" + practiceArray[loopcount].idme;
        divLink2.setAttributeNode(hrme2);

        var stockimg2 = document.createElement("img");
        stockimg2.className = "practiceimg";
        var srcme2 = document.createAttribute("src");
        srcme2.value = practiceArray[loopcount].ImgUrl;
        stockimg2.setAttributeNode(srcme2);
        divLink2.appendChild(stockimg2);

        var stockcaption2 = document.createElement("h4");
        stockcaption2.id = "captionmepractice-" + loopcount;
        stockcaption2.className = "practices-img-header";
        stockcaption2.innerHTML = practiceArray[loopcount].Title;
        divLink2.appendChild(stockcaption2);

        var imgDivd2 = document.createElement("div");
        imgDivd2.className = "practices-Absolute-imgDiv";
        imgDivd2.setAttribute("onmouseover", "oddfadein(this," + (loopcount + 20000) + ")");
        imgDivd2.setAttribute("onmouseout", "oddfadeout(this," + (loopcount + 20000) + ")");
        divLink2.appendChild(imgDivd2);

        where.appendChild(divLink2);
        sendarray.push([divLink2, stockimg2, stockcaption2]);

        buttonlinks[0].onmousedown = "asyncDelete('/Practices/Delete/',  { NameOrid: '" + practiceArray[loopcount].idme + "', LangAbr: '" + crumbstr.Abbreviation + "'} , 'divmelinkssc-" + loopcount + "')";
        buttonlinks[1].address = "/Practices/Edit/?id=" + practiceArray[loopcount].idme;
        putlinkss(divLink2, 730, buttonlinks, "right", "0px", "0px");
    }


    window.addEventListener("load", function () {
        var divheight = 0;
        var percenttop = 0;
        if (stockimg2 !== undefined) {
            divheight = parseFloat(window.getComputedStyle(stockimg2).getPropertyValue("height"));
            percenttop = (divheight - parseFloat(window.getComputedStyle(stockcaption2).getPropertyValue("height"))) / 2 * 100 / divheight;
        }
        else {
            divheight = parseFloat(window.getComputedStyle(stockimg).getPropertyValue("height"));
            percenttop = (divheight - parseFloat(window.getComputedStyle(stockcaption).getPropertyValue("height"))) / 2 * 100 / divheight;
        }

        for (var i = 0; i < practiceArray.length; i++) {
            setHeighttoElems(sendarray[i][0], [sendarray[i][1]]);
            sendarray[i][2].style.top = percenttop + "%";
            animate(sendarray[i][0], 500 + i, "opacity", 1, (i * 600) + 1000, true);
        }
    });

    window.addEventListener("resize", function () {
        for (var i = 0; i < practiceArray.length; i++) {
            setHeighttoElems(sendarray[i][0], [sendarray[i][1]]);
        }
    });
}