function getBig(elem, id) {
    animate(elem, id, "width", "305px", 260, true);
    animate(elem, id + 100, "height", "457px", 260, true);
    animate(elem, id + 200, "margin-left", "-2.5px", 260, true);
}

function getSmall(elem, id) {
    animate(elem, id, "width", "300px", 260, true);
    animate(elem, id + 100, "height", "450px", 260, true);
    animate(elem, id + 200, "margin-left", "0px", 260, true);
}

function centerThese(where, these = [], horzspaceBetween = 50, vertspaceBetween = 50) {
    var availableWidth = parseInt(window.getComputedStyle(where).getPropertyValue("width")); availableWidth
    var spaceUsed = 0;
    var rowWidths = [];
    var rowheight = 0;
    var rowhead = 0;
    var height = 0;
    for (var i = 0; i < these.length; i++) {
        var elemWidth = parseInt(window.getComputedStyle(these[i]).getPropertyValue("width"));
        var elemHeight = parseInt(window.getComputedStyle(these[i]).getPropertyValue("height"));
        if (spaceUsed + elemWidth > availableWidth) {
            height = height + vertspaceBetween + rowheight;
            rowheight = elemHeight;

            var offForCenter = (availableWidth - spaceUsed + horzspaceBetween) / 2;
            console.log(spaceUsed);
            for (var a = rowhead; a < i; a++) {
                these[a].style.left = offForCenter + "px";
                offForCenter = offForCenter + rowWidths[a - rowhead] + horzspaceBetween;
            }
            rowWidths.length = 0;
            console.log(rowWidths);
            rowhead = i;
            spaceUsed = 0;
        }
        rowWidths.push(elemWidth);
        these[i].style.top = height + "px";
        spaceUsed = spaceUsed + elemWidth + horzspaceBetween;

        if (rowheight < elemHeight) {
            rowheight = elemHeight;
        }
    }

    offForCenter = (availableWidth - spaceUsed + horzspaceBetween) / 2;
    for (a = rowhead; a < i; a++) {
        these[a].style.left = offForCenter + "px";
        offForCenter = offForCenter + rowWidths[a - rowhead] + horzspaceBetween;
    }

    height = height + rowheight + "px";

    where.style.height = height;
}