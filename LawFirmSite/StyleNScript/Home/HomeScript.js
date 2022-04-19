var changedif = 2;
function fadein(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "101%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "28px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "101%", 300, true);
    
    animate(elem, id, "opacity", "1", 300, true);
}

function fadeout(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "100%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "24px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "100%", 300, true);

    animate(elem, id, "opacity", "0", 300, true);
}

function oddfadein(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "101%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "28px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "101%", 300, true);

    animate(elem, id, "opacity", "1", 300, true);
}

function oddfadeout(elem, id) {
    animate(elem.parentElement.childNodes[2], id + 200, "width", "100%", 300, true);
    animate(elem.parentElement.childNodes[1], id + 100, "font-size", "24px", 200, true);
    animate(elem.parentElement.childNodes[0], id + 300, "width", "100%", 300, true);

    animate(elem, id, "opacity", "0", 300, true);
}


function putPractices(where, practiceArray) {

    var loopcount = practiceArray.length % 2 === 0 ? practiceArray.length : practiceArray.length - 1;
    
    var sendarray = [];

    for (var abi = 0; abi < loopcount; abi++) {

        var divLink = document.createElement("a");
        divLink.id = "imgd-" + (abi + "");
        divLink.style.opacity = 0;
        divLink.className = "linkCssme";
        var hrme = document.createAttribute("href");
        hrme.value = "/Practices/Practice/?id=" + practiceArray[abi].idme;
        divLink.setAttributeNode(hrme);

        var stockimg = document.createElement("img");
        stockimg.className = "practiceimg";
        var srcme = document.createAttribute("src");
        srcme.value = practiceArray[abi].ImgUrl;
        stockimg.setAttributeNode(srcme);
        divLink.appendChild(stockimg);

        var stockcaption = document.createElement("h4");
        stockcaption.className = "practices-img-header";
        stockcaption.id = "captionmepractice-" + i;
        stockcaption.innerHTML = practiceArray[abi].Title;
        divLink.appendChild(stockcaption);

        var imgDivd = document.createElement("div");
        imgDivd.className = "practices-Absolute-imgDiv";
        imgDivd.setAttribute("onmouseover", "fadein(this," + (abi + 2000000) + ")");
        imgDivd.setAttribute("onmouseout", "fadeout(this," + (abi + 2000000) + ")");
        divLink.appendChild(imgDivd);

        where.appendChild(divLink);
        sendarray.push([divLink, stockimg, stockcaption]);
    }

    if (loopcount !== practiceArray.length) {
        var divLink2 = document.createElement("a");
        divLink2.id = "imgd-" + (loopcount + "");
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
        stockcaption2.className = "practices-img-header";
        stockcaption2.id = "captionmepractice-" + loopcount;
        stockcaption2.innerHTML = practiceArray[loopcount].Title;
        divLink2.appendChild(stockcaption2);

        var imgDivd2 = document.createElement("div");
        imgDivd2.className = "practices-Absolute-imgDiv";
        imgDivd2.setAttribute("onmouseover", "oddfadein(this," + (loopcount + 2000000) + ")");
        imgDivd2.setAttribute("onmouseout", "oddfadeout(this," + (loopcount + 2000000) + ")");
        divLink2.appendChild(imgDivd2);

        where.appendChild(divLink2);
        sendarray.push([divLink2, stockimg2, stockcaption2]);
    }



    window.addEventListener("load", function () {
        var divheight = parseFloat(window.getComputedStyle(stockimg2).getPropertyValue("height"));
        var percenttop = (divheight - parseFloat(window.getComputedStyle(stockcaption2).getPropertyValue("height"))) / 2 * 100 / divheight;
        for (var i = 0; i < practiceArray.length; i++) {
            setHeighttoElems(sendarray[i][0], [sendarray[i][1]]);
            sendarray[i][2].style.top = percenttop + "%";
            //animate(sendarray[i][0], 500 + i, "opacity", 1, (i * 600) + 1000, true);
        }
    });

    window.addEventListener("resize", function () {
        for (var i = 0; i < practiceArray.length; i++) {
            setHeighttoElems(sendarray[i][0], [sendarray[i][1]]);
        }
    });
}

function scrolltop() {
    return typeof window.pageYOffset !== undefined ? window.pageYOffset : document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop ? document.body.scrollTop : 0;
}