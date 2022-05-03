//toast
//import * as pickup from '../client/pickup-steps.js'

//header
let _stateId = 0
getStateBranches()
//return list states has branches
function getStateBranches(){
    if(!$('#search-location').hasClass('step-hidden')) 
        $('#search-location').addClass('step-hidden')
    if(!$('#title-location').children('button').hasClass('step-hidden'))
        $('#title-location').children('button').addClass('step-hidden')
    $('#title-location').children('p').text("State/Province")
    $('#title-location').children('p').css('text-align', 'center')
    $.ajax({
        url: base_url+`/Location/StatesHaveBranches`,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#location-list').empty()
            response.forEach(item => {
                let a = `<li style="position: relative;">
                        <a type="button"
                            onclick="getCitiesBranches(${item.Id})">${item.Name}</a>
                        <i class="fa-solid fa-chevron-right"
                            style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
                    </li>`
                $('#location-list').append(a)
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
}
//return list cities has branches
function getCitiesBranches(stateId) {
    $('#title-location').children('p').text("City/District")
    $('#search-location').removeClass('step-hidden')
    $('#title-location').children('button').removeClass('step-hidden')
    $('#title-location').children('p').css('width', '65%')
    $('#title-location').children('p').css('text-align', '')
    $.ajax({
        url: base_url+`/Location/CitiesHaveBranches?stateId=${stateId}`,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#location-list').empty()
            response.forEach(item => {
                let a = `<li style="position: relative;">
                        <a type="button" onclick="getBranchesByCity(${item.Id})">${item.Name}</a>
                            <i class="fa-solid fa-chevron-right"
                                style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
                        </li>`
                $('#location-list').append(a)
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
    _stateId = stateId
}
//return list branches
function getBranchesByCity(cityId) {
    $.ajax({
        url: base_url+`/Location/GetBranchesByCities?cityId=${cityId}`,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#location-list').empty()
            $('#title-location').children('p').text("Branch")
            if(response == null) return
            response.forEach(item => {
                let branch = `${item.name}, ${item.address}, ${item.wardName}, ${item.cityName}, ${item.provinceName}`
                let a = `<li>
                            <a type="button" onclick="getBranches(${item.id})">
                                ${branch}                                                             
                            </a>
                        </li>`
                $('#location-list').append(a)
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
} 

function getBranches(id){
    $.ajax({
        url: base_url+`/Location/GetBranchesByCities?cityId=0&branchId=`+id,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#choose-branch').children('a').find('p').css('font-size', '12px')
            $('#choose-branch').children('a').find('p').css('line-height', '18px')
            $('#choose-branch').children('a').find('p').css('height', '35px')
            response.forEach(item => {
                let branch = `${item.name}, ${item.address}, ${item.wardName}, ${item.cityName}, ${item.provinceName}`
                $('#choose-branch').children('a').find('p').text(branch)
                document.cookie = "branch="+JSON.stringify(item)
                if($('.postoffice-form').hasClass('disable-section')) $('.postoffice-form').removeClass('disable-section')
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
}

$('#title-location').children('button').on('click', () => {
    let title = $('#title-location').children('p').text()
    switch(title){
        case "City/District":
            getStateBranches()
            break
        case "Branch":
            getCitiesBranches(_stateId)
    }
})

$('#choose-branch').children('ul').on('mouseleave', () => {
    getStateBranches()
})

//search
function onSearchLocation() {
    // Declare variables
    var input, filter, div, li, a, i, txtValue;
    input = document.getElementById("location-search");
    filter = input.value.toUpperCase();
    div = document.getElementById("location-list");
    li = div.getElementsByTagName('li');

    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
        li[i].style.display = "";
        } else {
        li[i].style.display = "none";
        }
    }
}