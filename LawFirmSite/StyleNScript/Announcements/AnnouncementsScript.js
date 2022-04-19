function getABig(elem, id) {
    animate(elem, id, "width", "245px", 260, true);
    animate(elem, id + 100, "height", "330px", 260, true);
    animate(elem, id + 200, "margin-left", "1%", 260, true);
}

function getASmall(elem, id) {
    animate(elem, id, "width", "240px", 260, true);
    animate(elem, id + 100, "height", "320px", 260, true);
    animate(elem, id + 200, "margin-left", "2%", 260, true);
}