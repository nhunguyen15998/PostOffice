function getCookie(name) {
    let _cookie = name + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let singleCookies = decodedCookie.split(';');
    for(let i = 0; i <singleCookies.length; i++) {
        let singleCookie = singleCookies[i];
        while (singleCookie.charAt(0) == ' ') {
            singleCookie = singleCookie.substring(1);
        }
        if (singleCookie.indexOf(_cookie) == 0) {
            return singleCookie.substring(_cookie.length, singleCookie.length);
        }
    }
    return "";
}

function checkCookie() {
    let branch = getCookie('branch')
    if (branch != "") {
        branch = JSON.parse(branch)
        let txt = `${branch.name}, ${branch.address}, ${branch.wardName}, ${branch.cityName}, ${branch.provinceName}`
        $('#choose-branch').children('a').find('p').text(txt)
        $('#choose-branch').children('a').find('p').css('font-size', '12px')
        $('#choose-branch').children('a').find('p').css('line-height', '18px')
        $('#choose-branch').children('a').find('p').css('height', '35px')
        return branch
    } else return null
}
checkCookie()