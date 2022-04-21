//header
let _countryId = 0
let _stateId = 0
//return list countries 
function loadCountries(){
    $('#search-location').addClass('step-hidden')
    $('#title-location').children('button').addClass('step-hidden')
    $('#title-location').children('p').css('width', '100%')
    $('#title-location').children('p').css('text-align', 'center')
    $.ajax({
        url: 'https://localhost:5001/Location/GetCountries',
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#location-list').empty()
            $('#title-location').children('p').text("Country")
            response.forEach(country => {
                let li = `<li style="position: relative;">
                            <a type="button"
                        onclick="getStateBranches(${country.Id})">${country.Name}</a>
                            <i class="fa-solid fa-chevron-right"
                        style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
                        </li>`
                $('#location-list').append(li)
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
}
loadCountries()
//return list states has branches
function getStateBranches(countryId){
    $.ajax({
        url: `https://localhost:5001/Location/StatesHaveBranches?countryId=${countryId}`,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            console.log(response)
            $('#location-list').empty()
            $('#search-location').removeClass('step-hidden')
            $('#title-location').children('button').removeClass('step-hidden')
            $('#title-location').children('p').text("State/Province")
            $('#title-location').children('p').css('width', '65%')
            $('#title-location').children('p').css('text-align', '')
            let arr = new Array()
            response.forEach(item => {
                if(!arr.includes(item.Id)){
                    let a = `<li style="position: relative;">
                            <a type="button"
                                onclick="getCitiesBranches(${item.Id})">${item.Name}</a>
                            <i class="fa-solid fa-chevron-right"
                                style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
                        </li>`
                    $('#location-list').append(a)
                    arr.push(item.Id)
                }
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
    _countryId = countryId
}
//return list cities has branches
function getCitiesBranches(stateId) {
    $.ajax({
        url: `https://localhost:5001/Location/CitiesHaveBranches?stateId=${stateId}`,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#location-list').empty()
            $('#title-location').children('p').text("City/District")
            let arr = new Array()
            response.forEach(item => {
                if(!arr.includes(item.Id)){
                    let a = `<li style="position: relative;">
                            <a type="button" onclick="getWardsByCity(${item.Id})">${item.Name}</a>
                                <i class="fa-solid fa-chevron-right"
                                    style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
                            </li>`
                    $('#location-list').append(a)
                    arr.push(item.Id)
                }
            })
        },
        error: function (data) {
            alert(data.responseText.message)
        }
    })
    _stateId = stateId
}
//return list branches
function getWardsByCity(cityId) {
    $.ajax({
        url: `https://localhost:5001/Location/GetBranchesByCities?cityId=${cityId}`,
        type: 'get',
        dataType: 'json',
        contentType: 'applicaton/json',
        success: function (response) {
            $('#location-list').empty()
            $('#title-location').children('p').text("Branch")
            if(response == null) return
            response.forEach(item => {
                let a = `<li>
                            <a type="button" onclick="">${item.Name}</a>
                        </li>`
                $('#location-list').append(a)
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
        case "State/Province":
            loadCountries()
            break
        case "City/District":
            getStateBranches(_countryId)
            break
        case "Ward":
            getCitiesBranches(_stateId)
    }
})

$('#choose-branch').children('ul').on('mouseleave', () => {
    loadCountries()
})


////////////////////

// function getStatesByCountry(countryId) {
//     $.ajax({
//         url: `https://localhost:5001/Location/GetStatesByCountry?countryId=${countryId}`,
//         type: 'get',
//         dataType: 'json',
//         contentType: 'applicaton/json',
//         success: function (response) {
//             $('#location-list').empty()
//             $('#search-location').removeClass('step-hidden')
//             $('#title-location').children('button').removeClass('step-hidden')
//             $('#title-location').children('p').text("State/Province")
//             $('#title-location').children('p').css('width', '65%')
//             $('#title-location').children('p').css('text-align', '')
//             response.forEach(item => {
//                 let a = `<li style="position: relative;">
//                             <a type="button"
//                                 onclick="getCitiesByState(${item.Id})">${item.Name}</a>
//                             <i class="fa-solid fa-chevron-right"
//                                 style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
//                         </li>`
//                 $('#location-list').append(a)
//             })
//         },
//         error: function (data) {
//             alert(data.responseText.message)
//         }
//     })
// }

// function getCitiesByState(stateId) {
//     $.ajax({
//         url: `https://localhost:5001/Location/GetCitiesByState?stateId=${stateId}`,
//         type: 'get',
//         dataType: 'json',
//         contentType: 'applicaton/json',
//         success: function (response) {
//             $('#location-list').empty()
//             $('#title-location').children('p').text("City/District")
//             response.forEach(item => {
//                 let a = `<li style="position: relative;">
//                             <a type="button" onclick="getWardsByCity(${item.Id})">${item.Name}</a>
//                             <i class="fa-solid fa-chevron-right"
//                                 style="position: absolute;top: 18px;right: 16px;color: #ffdc39;font-size: 10px;"></i>
//                         </li>`
//                 $('#location-list').append(a)
//             })
//         },
//         error: function (data) {
//             alert(data.responseText.message)
//         }
//     })
//     _stateId = stateId
// }

// function getWardsByCity(cityId) {
//     $.ajax({
//         url: `https://localhost:5001/Location/GetWardsByCity?cityId=${cityId}`,
//         type: 'get',
//         dataType: 'json',
//         contentType: 'applicaton/json',
//         success: function (response) {
//             $('#location-list').empty()
//             $('#title-location').children('p').text("Ward")
//             if(response == null) return
//             response.forEach(item => {
//                 let a = `<li>
//                             <a type="button" onclick="">${item.Name}</a>
//                         </li>`
//                 $('#location-list').append(a)
//             })
//         },
//         error: function (data) {
//             alert(data.responseText.message)
//         }
//     })
// }





