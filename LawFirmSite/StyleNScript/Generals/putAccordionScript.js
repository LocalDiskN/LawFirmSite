function putAccordion(where, idOff, howmany, buttids = [], delbutts) {
    var accs = [];
    var accmain = document.createElement("div");
    accmain.className = "accordion";
    accmain.id = "accordion-" + idOff;
    where.appendChild(accmain);

    howmany = howmany + idOff;

    for (var i = idOff; i < howmany - buttids.length; i++) {
        buttids.push("accButt-" + i);
    }

    for (var itr = 0; idOff < howmany; idOff++) {
        var accC = document.createElement("div");
        accC.id = "accheadme-" + idOff;
        accC.style.position = "relative";
        accC.className = "card";
        accmain.appendChild(accC);

        var accChead = document.createElement("div");
        accChead.className = "card-header";
        accChead.id = "heading-" + idOff;
        accC.appendChild(accChead);

        var accHeadH = document.createElement("h5");
        accHeadH.className = "mb-0";
        accChead.appendChild(accHeadH);

        var accHeadButt = document.createElement("button");
        accHeadButt.id = buttids[itr];
        accHeadButt.className = "linkCss btn btn-link collapsed namemebyid";
        accHeadButt.setAttribute("type", "button");
        accHeadButt.setAttribute("data-toggle", "collapse");
        accHeadButt.setAttribute("data-target", "#collapse-" + idOff);
        accHeadButt.setAttribute("aria-expanded", "false");
        accHeadButt.setAttribute("aria-controls", "collapse-" + idOff);
        accChead.appendChild(accHeadButt);


        var accColl = document.createElement("div");
        accColl.className = "collapse";
        accColl.id = "collapse-" + idOff;
        accColl.setAttribute("aria-labelledby", "heading-" + idOff);
        accColl.setAttribute("data-parent", "#" + accmain.id);
        accC.appendChild(accColl);

        var accCollC = document.createElement("div");
        accCollC.className = "card-body accordionbodyback";
        accColl.appendChild(accCollC);
        accs.push(accCollC);

        if (delbutts !== undefined) {

            delbutts[itr].onmousedown = delbutts[itr].onmousedown.substr(0, delbutts[itr].onmousedown.lastIndexOf(",") + 1) + "'" + accC.id + "'"+ delbutts[itr].onmousedown.substr(delbutts[itr].onmousedown.lastIndexOf(")"));

            putlinkss(accC, (idOff * 4), [delbutts[itr]], "right", "40px", "20px");
        }

        itr++;
    }

    return accs;
}

function appendAccordion(where, idOff, howmany, buttids = [], delbutts) {
    var accs = [];
    
    howmany = howmany + idOff;

    for (var i = idOff; i < howmany - buttids.length; i++) {
        buttids.push("accButt-" + i);
    }

    for (var itr = 0; idOff < howmany; idOff++) {
        var accC = document.createElement("div");
        accC.id = "accheadme-" + idOff;
        accC.style.position = "relative";
        accC.className = "card";
        where.appendChild(accC);

        var accChead = document.createElement("div");
        accChead.className = "card-header";
        accChead.id = "heading-" + idOff;
        accC.appendChild(accChead);

        var accHeadH = document.createElement("h5");
        accHeadH.className = "mb-0";
        accChead.appendChild(accHeadH);

        var accHeadButt = document.createElement("button");
        accHeadButt.id = buttids[itr];
        accHeadButt.innerHTML = buttids[itr];
        accHeadButt.className = "linkCss btn btn-link collapsed namemebyid";
        accHeadButt.setAttribute("type", "button");
        accHeadButt.setAttribute("data-toggle", "collapse");
        accHeadButt.setAttribute("data-target", "#collapse-" + idOff);
        accHeadButt.setAttribute("aria-expanded", "false");
        accHeadButt.setAttribute("aria-controls", "collapse-" + idOff);
        accChead.appendChild(accHeadButt);


        var accColl = document.createElement("div");
        accColl.className = "collapse";
        accColl.id = "collapse-" + idOff;
        accColl.setAttribute("aria-labelledby", "heading-" + idOff);
        accColl.setAttribute("data-parent", "#" + where.id);
        accC.appendChild(accColl);

        var accCollC = document.createElement("div");
        accCollC.className = "card-body accordionbodyback";
        accColl.appendChild(accCollC);
        accs.push(accCollC);
        
        if (delbutts !== undefined) {

            delbutts[itr].onmousedown = delbutts[itr].onmousedown.substr(0, delbutts[itr].onmousedown.lastIndexOf(",") + 1) + "'" + accC.id + "'" + delbutts[itr].onmousedown.substr(delbutts[itr].onmousedown.lastIndexOf(")"));

            putlinkss(accC, (idOff * 4), [delbutts[itr]], "right", "40px", "20px");
        }

        itr++;
    }

    return accs;
}