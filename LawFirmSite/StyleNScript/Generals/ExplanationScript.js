var topMarPer = 15;

function putExplan(where, explanArray) {
    var divs = [];

    for (var i = 0; i < explanArray.length; i++) {
        var expDiv = document.createElement("div");
        expDiv.className = "explanDiv";
        expDiv.id = "imlabdivParent" + i;
        var headTitle = document.createElement("h1");
        var imgme = document.createElement("img");
        var labelme = document.createElement("div");

        if (explanArray[i].Align === "left") {
            headTitle.className = "leftHeader";
            labelme.className = "explanLabelL";
            labelme.style.left = "33%";
        }
        else if (explanArray[i].Align === "center") {
            headTitle.className = "centerHeader";
            labelme.className = "explanLabelL";
            labelme.style.left = "33%";
        }
        else {
            headTitle.className = "rightHeader";
            labelme.className = "explanLabelR";
            imgme.style.left = "68%";
        }
        if (explanArray[i].ImgUrl === "" || explanArray[i].ImgUrl === null) {
            labelme.style.width = "100%";
            labelme.style.marginLeft = "-33%";
        }
        
        headTitle.id = "imlabdiv" + i + "-head";
        headTitle.innerHTML = explanArray[i].Title;
        expDiv.appendChild(headTitle);

        var imlabdiv = document.createElement("div");
        imlabdiv.style.marginTop = "3%";
        imlabdiv.id = "imlabdiv" + i;

        imgme.id = "imlabdiv" + i + "-img";
        imgme.className = "eximgDiv";
        var srcme = document.createAttribute("src");
        srcme.value = explanArray[i].ImgUrl;
        imgme.setAttributeNode(srcme);
        imlabdiv.appendChild(imgme);

        labelme.id = "imlabdiv" + i + "-label";
        labelme.innerHTML = explanArray[i].Content;
        imlabdiv.appendChild(labelme);
        expDiv.appendChild(imlabdiv);
        where.appendChild(expDiv);

        divs.push(document.getElementById("imlabdiv" + i));
    }
    return divs;
}

function setExplanAlign(imlabdivid, alignment) {

    if (alignment === "left") {
        document.getElementById(imlabdivid + "-head").className = "leftHeader";
        document.getElementById(imlabdivid + "-label").className = "explanLabelL";
        document.getElementById(imlabdivid + "-label").style.left = "33%";
        document.getElementById(imlabdivid + "-img").style.left = "0%";
    }
    else if (alignment === "center") {
        document.getElementById(imlabdivid + "-head").className = "centerHeader";
        document.getElementById(imlabdivid + "-label").className = "explanLabelL";
        document.getElementById(imlabdivid + "-label").style.left = "33%";
        document.getElementById(imlabdivid + "-img").style.left = "0%";
    }
    else {
        document.getElementById(imlabdivid + "-head").className = "rightHeader";
        document.getElementById(imlabdivid + "-label").className = "explanLabelR";
        document.getElementById(imlabdivid + "-label").style.left = "0%";
        document.getElementById(imlabdivid + "-img").style.left = "68%";
    }
}