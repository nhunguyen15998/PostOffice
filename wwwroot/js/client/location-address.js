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
        url: `Location/StatesHaveBranches`,
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
        url: `Location/CitiesHaveBranches?stateId=${stateId}`,
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
        url: `Location/GetBranchesByCities?cityId=${cityId}`,
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
        url: `Location/GetBranchesByCities?cityId=0&branchId=`+id,
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


////////////////////PICKUP---PROVINCE---DISTRICT---WARD

//get provinces
getProvinces()
function getProvinces(){
    $.ajax({
        url : 'Location/GetStates',
        type : 'get',
        dataType : 'json',
        contentType : 'application/json',
        success: function(response){
            $("#sender-province").children("ul").find("div").empty();
            response.forEach(item => {
                let li = `<li style="padding: 0 20px;font-size: 13px;" id="sender-province-${item.Id}" data-id="${item.Id}" data-province-value="${item.Name}">
                            <a role="button" onclick="getDistrictsByProvince(${item.Id})">${item.Name}</a>
                        </li>`
                $("#sender-province").children("ul").find("div").append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
    })
}

//get districts by province
function getDistrictsByProvince(provinceId){
    let provinceValue = $("#sender-province").children("ul").find(`#sender-province-${provinceId}`).attr('data-province-value')
    $("#sender-province").find("button").text(provinceValue)
    $("#sender-province").find("button").attr('data-province', provinceId)
    $("#sender-province").find("button").attr('data-province-value', provinceValue)
    $.ajax({
        url : 'Location/GetCitiesByState?provinceId='+provinceId,
        type : 'get',
        dataType : 'json',
        contentType : 'application/json',
        success: function(response){
            $("#sender-district").children("ul").find("div").empty();
            response.forEach(item => {
                let li = `<li style="padding: 0 20px;font-size: 13px;" id="sender-district-${item.Id}" data-id="${item.Id}" data-district-value="${item.Name}">
                            <a role="button" onclick="getWardsByDistrict(${item.Id})">${item.Name}</a>
                        </li>`
                $("#sender-district").children("ul").find("div").append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
    })
}

//get wards by district
function getWardsByDistrict(districtId){
    let districtValue = $("#sender-district").children("ul").find(`#sender-district-${districtId}`).attr('data-district-value')
    $("#sender-district").find("button").text(districtValue)
    $("#sender-district").find("button").attr('data-district', districtId)
    $("#sender-district").find("button").attr('data-district-value', districtValue)
    $.ajax({
        url : 'Location/GetWardsByCity?districtId='+districtId,
        type : 'get',
        dataType : 'json',
        contentType : 'application/json',
        success: function(response){
            $("#sender-ward").children("ul").find("div").empty();
            response.forEach(item => {
                let li = `<li style="padding: 0 20px;font-size: 13px;" id="sender-ward-${item.Id}" data-id="${item.Id}" data-ward-value="${item.Name}">
                            <a role="button" onClick="selectWard(${item.Id})">${item.Name}</a>
                        </li>`
                $("#sender-ward").children("ul").find("div").append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
    })
}

function selectWard(wardId){
    let wardValue = $("#sender-ward").children("ul").find(`#sender-ward-${wardId}`).attr('data-ward-value')
    $("#sender-ward").find("button").text(wardValue)
    $("#sender-ward").find("button").attr('data-ward', wardId)
    $("#sender-ward").find("button").attr('data-ward-value', wardValue)
}

/////////////////////////////////##################RECEIVER###################
//getReceiverProvinces
getReceiverProvinces(1)
function getReceiverProvinces(index){
    $.ajax({
        url : 'Location/GetStates',
        type : 'get',
        dataType : 'json',
        contentType : 'application/json',
        success: function(response){
            $(`#receiver-province-${index}`).children("ul").find("div").empty();
            response.forEach(item => {
                let li = `<li style="padding: 0 20px;font-size: 13px;" id="receiver-province-${item.Id}-${index}" data-id="${item.Id}" data-province-value="${item.Name}">
                            <a role="button" onclick="getReceiverDistrictsByProvince(${item.Id}, ${index})">${item.Name}</a>
                        </li>`
                $(`#receiver-province-${index}`).children("ul").find("div").append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
    })
}
//getReceiverDistricts
function getReceiverDistrictsByProvince(provinceId, index){
    let provinceValue = $(`#receiver-province-${index}`).children("ul").find(`#receiver-province-${provinceId}-${index}`).attr('data-province-value')
    $(`#receiver-province-${index}`).find("button").text(provinceValue)
    $(`#receiver-province-${index}`).find("button").attr('data-province', provinceId)
    $(`#receiver-province-${index}`).find("button").attr('data-province-value', provinceValue)
    $.ajax({
        url : 'Location/GetCitiesByState?provinceId='+provinceId,
        type : 'get',
        dataType : 'json',
        contentType : 'application/json',
        success: function(response){
            $(`#receiver-district-${index}`).children("ul").find("div").empty();
            response.forEach(item => {
                let li = `<li style="padding: 0 20px;font-size: 13px;" id="receiver-district-${item.Id}-${index}" data-id="${item.Id}" data-district-value="${item.Name}">
                            <a role="button" onclick="getReceiverWardsByDistrict(${item.Id}, ${index})">${item.Name}</a>
                        </li>`
                $(`#receiver-district-${index}`).children("ul").find("div").append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
    })
}
//getReceiverWards
function getReceiverWardsByDistrict(districtId, index){
    let districtValue = $(`#receiver-district-${index}`).children("ul").find(`#receiver-district-${districtId}-${index}`).attr('data-district-value')
    $(`#receiver-district-${index}`).find("button").text(districtValue)
    $(`#receiver-district-${index}`).find("button").attr('data-district', districtId)
    $(`#receiver-district-${index}`).find("button").attr('data-district-value', districtValue)
    $.ajax({
        url : 'Location/GetWardsByCity?districtId='+districtId,
        type : 'get',
        dataType : 'json',
        contentType : 'application/json',
        success: function(response){
            $(`#receiver-ward-${index}`).children("ul").find("div").empty();
            response.forEach(item => {
                let li = `<li style="padding: 0 20px;font-size: 13px;" id="receiver-ward-${item.Id}-${index}" data-id="${item.Id}" data-ward-value="${item.Name}">
                            <a role="button" onClick="selectReceiverWard(${item.Id}, ${index})">${item.Name}</a>
                        </li>`
                $(`#receiver-ward-${index}`).children("ul").find("div").append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
    })
}
//selectReceiverWards
function selectReceiverWard(wardId, index){
    let wardValue = $(`#receiver-ward-${index}`).children("ul").find(`#receiver-ward-${wardId}-${index}`).attr('data-ward-value')
    $(`#receiver-ward-${index}`).find("button").text(wardValue)
    $(`#receiver-ward-${index}`).find("button").attr('data-ward', wardId)
    $(`#receiver-ward-${index}`).find("button").attr('data-ward-value', wardValue)
}