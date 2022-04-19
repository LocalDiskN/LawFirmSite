
function contactEdit(conmainOff, conid) {
    var contentme = "";

    var conmes = document.getElementsByClassName("subContlabel-" + conmainOff);

    for (var i = 0; i < conmes.length; i++) {
        contentme = contentme + conmes[i].innerHTML + "/77334sa524/453f8675/";
    }

    var editmodel = {
        lang: crumbstr.Abbreviation,
        idme: parseInt(conid), Title: document.getElementById("conhead-" + conmainOff).innerHTML,
        Cicon: document.getElementById("subCont-" + conmainOff + "-0").innerHTML,
        Contents: contentme
    };

    asyncEdit("/Contact/Edit/", editmodel);
}

function contactAddSub(conmainOff, conid) {
    var parinfdiv = document.getElementById("mainCont-" + conmainOff);
    var i = conmainOff;
    var a = parinfdiv.childNodes.length;
    
    var deletelinks = [
        { inner: '<i class="fas fa-times"></i>', class: "buttonLink redbuttonLinkhollow", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Delete"), class: "buttonLink redbuttonLinkhollow", onmousedown: "" } }
    ];

    var childinfdiv = document.createElement("div");
    childinfdiv.id = "childinfdiv-" + i + "-" + a;
    childinfdiv.className = "childinfdiv mb-4";
    parinfdiv.appendChild(childinfdiv);

    var cont = document.createElement("div");
    cont.id = "subCont-" + i + "-" + (a + 1);
    cont.className = "conp subContlabel-" + i;
    childinfdiv.appendChild(cont);

    var htmledit = document.createElement("div");
    htmledit.id = "htmledit-" + i + "-" + (a + 1);
    htmledit.className = "htmledit";
    childinfdiv.appendChild(htmledit);

    deletelinks[0].onmousedown = "asyncDelete('/Contact/Delete/',  { NameOrid: '" + conid + "-" + a + "', LangAbr: '" + crumbstr.Abbreviation + "'} , 'childinfdiv-" + i + "-" + a + "')";
    putlinkss(childinfdiv, ((i + 1) * -10) - a - 1, deletelinks, "left", "-40px", "30px");

    putHTMLEditor(document.getElementById("htmledit-" + i + "-" + (a + 1)), 78900 * (i * 100) + (-1 * a), { x: "90%", y: "30px", ymax: "30px", ymin: "30px" }, [document.getElementById("subCont-" + i + "-" + (a + 1))], ["all"], getValueFromDic(crumbstr.Content, "FillMe"));
}

function contactAdd(conmainOff) {

    var createmodel = {
        LangAbr: crumbstr.Abbreviation, NameOrid: 0
    };

    $.ajax({
        type: 'POST',
        url: "/Contact/Create/",
        dataType: 'json',
        data: { createmodel: createmodel },

        success: function (data, textStatus, jqXHR) {

            if (data.createmodel !== undefined) {
                var deletelinks = [
                    { inner: '<i class="fas fa-times"></i>', class: "buttonLink redbuttonLinkhollow fullweigth", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Delete"), class: "buttonLink redbuttonLinkhollow", onmousedown: "" } }
                ];

                var addlinks = [
                    { inner: '<i class="fas fa-plus"></i>', class: "buttonLink bluebuttonLinkhollow fullweigth", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Add"), class: "buttonLink bluebuttonLinkhollow", onmousedown: "" } },
                    { inner: '<i class="fas fa-check"></i>', class: "buttonLink bluebuttonLinkhollow fullweigth", address: "", hmessage: { message: getValueFromDic(crumbstr.Content, "Save"), class: "buttonLink bluebuttonLinkhollow", onmousedown: "" } }
                ];

                var puteverythighere = document.getElementById("puteverythighere");
                var i = conmainOff;

                var parinfdiv = document.createElement("div");
                parinfdiv.id = "mainCont-" + i;
                parinfdiv.className = "parinfdiv";
                puteverythighere.appendChild(parinfdiv);

                var childinfdiv = document.createElement("div");
                childinfdiv.className = "childinfdiv mb-4";
                parinfdiv.appendChild(childinfdiv);

                var infohead = document.createElement("h5");
                infohead.id = "conhead-" + i;
                infohead.className = "conh";
                childinfdiv.appendChild(infohead);

                var htmledit = document.createElement("div");
                htmledit.id = "htmledit-" + i;
                htmledit.className = "htmledit";
                childinfdiv.appendChild(htmledit);


                putHTMLEditor(document.getElementById("htmledit-" + i), -78900 * (i * 100), { x: "90%", y: "30px", ymax: "30px", ymin: "30px" }, [document.getElementById("conhead-" + i)], ["all"], getValueFromDic(crumbstr.Content, "FillMe"));

                var childinfdiv2 = document.createElement("div");
                childinfdiv2.className = "childinfdiv mb-4";
                parinfdiv.appendChild(childinfdiv2);

                var cont = document.createElement("div");
                cont.id = "subCont-" + i + "-" + 0;
                cont.className = "conp";
                cont.style.color = "white";
                childinfdiv2.appendChild(cont);

                var htmledit2 = document.createElement("div");
                htmledit2.id = "htmledit-" + i + "-" + 0;
                htmledit2.className = "htmledit";
                childinfdiv2.appendChild(htmledit2);

                putHTMLEditor(document.getElementById("htmledit-" + i + "-0"), -78900 * (i * 99), { x: "90%", y: "30px", ymax: "30px", ymin: "30px" }, [document.getElementById("subCont-" + i + "-" + 0)], [], getValueFromDic(crumbstr.Content, "PutIcon"));

                deletelinks[0].onmousedown = "asyncDelete('/Contact/Delete/',  { NameOrid: '" + data.createmodel.NameOrid + "', LangAbr: '" + crumbstr.Abbreviation + "'} , 'mainCont-" + i + "')";
                putlinkss(parinfdiv, (i + 1) * - 10, deletelinks, "left", "0px", "0px");
                addlinks[1].onmousedown = "contactEdit(" + i + "," + data.createmodel.NameOrid + ")";
                addlinks[0].onmousedown = "contactAddSub(" + i + "," + data.createmodel.NameOrid + ")";
                putlinkss(parinfdiv, ((i + 1) * -10) - conmainOff - 3, addlinks, "left", "40px", "0px", "bottom");
                putMessage(data.createmodel.LangAbr, 2000);
            }
            else {
                putMessage(data, 2000);
            }
            
        },

        error: function () {
            alert('error');
        }
    });
}