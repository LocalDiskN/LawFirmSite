function post(path, params, method) {
    method = method || "post"; // Set method to post by default if not specified.

    // The rest of this code assumes you are not using a library.
    // It can be made less wordy if you use one.
    var form = document.createElement("form");
    form.setAttribute("method", method);
    form.setAttribute("action", path);

    for (var key in params) {
        if (params.hasOwnProperty(key)) {
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("type", "hidden");
            hiddenField.setAttribute("name", key);
            hiddenField.setAttribute("value", params[key]);

            form.appendChild(hiddenField);
        }
    }

    document.body.appendChild(form);
    form.submit();
}

function getRelativeImgUrl(url) {
    var fpos = url.indexOf("/Images");
    return url.substr(fpos);
}

var timeout;
function closemessage() {
    clearTimeout(timeout);
    animate(document.getElementById("messagemediv"), 999999, "opacity", 0, 100, true, "none");
}

function putMessage(data, puttime) {
    var body = document.getElementsByTagName('body')[0];
    var messaggediv = document.getElementById("messagemediv");
    var messaggedivme = document.getElementById("messagemedivme");
    var messagelabel = document.getElementById("messagemelabelme");
    if (messaggediv === undefined || messaggediv === null ) {
        messaggediv = document.createElement("div");

        messaggediv.id = "messagemediv";
        body.insertBefore(messaggediv, document.getElementById("navbarme").nextSibling);
        messaggedivme = document.createElement("div");
        messagelabel = document.createElement("label");
        messagelabel.id = "messagemelabelme";
        messaggedivme.id = "messagemedivme";
        messaggedivme.style.height = "100%";
        messaggedivme.style.width = "100%";
        messaggediv.appendChild(messaggedivme);
        messaggedivme.appendChild(messagelabel);
        putlinkss(messaggedivme, 999999, [{ inner: '<i class="fas fa-times"></i>', class: "buttonLink", address: "", hmessage: "", onmousedown: "closemessage()" }], "right", "30px", "10px");

    }
    if (data.success !== undefined && data.success !== null && data.success !== "") {

        messagelabel.innerHTML = data.success;
        messaggediv.className = "successdiv";
    }
    else if (data.error !== undefined && data.error !== null && data.error !== "") {
        messagelabel.innerHTML = data.error;
        messaggediv.className = "errordiv";
    }
    messaggediv.style.display = "block";
    messaggediv.style.opacity = 1;

    timeout = setTimeout(function () {
        clearTimeout(timeout);
        animate(messaggediv, 999999, "opacity", 0, 500, true, "none");
    }, puttime);
}

async function asyncDelete(hrefme, parameterme, fid) {
    $.ajax({
        type: 'POST',
        url: hrefme,
        dataType: 'json',
        data: { delmodel: parameterme },

        success: function (data, textStatus, jqXHR) {
            if (fid !== undefined && (data.error === undefined || data.error === null || data.error === "")) {
                document.getElementById(fid).parentNode.removeChild(document.getElementById(fid));
            }
            putMessage(data, 2000);
        },

        error: function () {
            alert('error');
        }
    });
}

async function asyncEdit(hrefme, parameterme) {
    $.ajax({
        type: 'POST',
        url: hrefme,
        dataType: 'json',
        data: { editmodel: parameterme },

        success: function (data, textStatus, jqXHR) {
            putMessage(data, 2000);
        },

        error: function () {
            alert('error');
        }
    });
}


async function asyncCreate(hrefme, parameterme) {
    $.ajax({
        type: 'POST',
        url: hrefme,
        dataType: 'json',
        data: { createmodel: parameterme },

        success: function (data, textStatus, jqXHR) {
            putMessage(data, 2000);
        },

        error: function () {
            alert('error');
        }
    });
}