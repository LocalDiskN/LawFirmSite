function empDelete(emppos, hrefme, parameterme, fid) {
    epms.splice(parseInt(emppos), 1);

    asyncDelete(hrefme, parameterme, fid);

    centerThese(mydiv, epms);
}