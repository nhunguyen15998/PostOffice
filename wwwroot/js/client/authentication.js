let userData = localStorage.getItem('user_data')

//sign up =========================================================
//validation - signup
let error = ""
$("input[name='first-name']").on('input', () =>{
    removeValidation("first-name-error")
    if($("input[name='first-name']").val().trim().length == 0){
        error = "Field first name is required"
        informError(error, "first-name-error")
    } else {
        informValidated("first-name-error")
    }
})
$("input[name='last-name']").on('input', () =>{
    removeValidation("last-name-error")
    if($("input[name='last-name']").val().trim().length == 0){
        error = "Field last name is required"
        informError(error, "last-name-error")
    } else {
        informValidated("last-name-error")
    }
})
$("input[name='phone']").on('input', () =>{
    removeValidation("phone-error")
    if($("input[name='phone']").val().trim().length == 0){
        error = "Field phone is required"
        informError(error, "phone-error")
    } else {
        informValidated("phone-error")
    }
})
$("input[name='email']").on('input', () =>{
    removeValidation("email-error")
    if($("input[name='email']").val().trim().length == 0){
        error = "Field email is required"
        informError(error, "email-error")
    } else {
        informValidated("email-error")
    }
})
$("input[name='password']").on('input', () =>{
    removeValidation("password-error")
    let password = $("input[name='password']").val().trim()
    let repeatPassword = $("input[name='repeat-password']").val().trim()
    if(password.length == 0){
        error = "Field password is required"
        informError(error, "password-error")
    }
    else if(password.length > 0 && repeatPassword.length > 0 && password !== repeatPassword){
        error = "Password don't match"
        removeValidation("repeat-password-error")
        informError(error, "repeat-password-error") 
        informValidated("password-error")
    }
    else{
        informValidated("password-error")
        if(repeatPassword.length > 0){
            removeValidation("repeat-password-error")
            informValidated("repeat-password-error")
        }
    }
})
$("input[name='repeat-password']").on('input', () =>{
    removeValidation("repeat-password-error")
    let password = $("input[name='password']").val().trim()
    let repeatPassword = $("input[name='repeat-password']").val().trim()
    if(repeatPassword.length == 0){
        error = "Field repeat password is required"
        informError(error, "repeat-password-error")
    }
    else if(repeatPassword.length > 0 && password !== repeatPassword){
        error = "Password don't match"
        $(`#repeat-password-error`).children().remove()
        informError(error, "repeat-password-error") 
    }
    else {
        informValidated("repeat-password-error")
    }
})

function checkSignUpNull(){
    if($(`#first-name`).val().trim() == "")
        informError("Field first name is required", "first-name-error")
    if($(`#last-name`).val().trim() == "")
       informError("Field last name is required", "last-name-error")
    if($(`#phone`).val().trim() == "")
        informError("Field phone is required", "phone-error")
    if($(`#email`).val().trim() == "")
        informError("Field email is required", "email-error")
    if($(`#password`).val().trim() == "")
        informError("Field password is required", "password-error")
    if($(`#repeat-password`).val().trim() == "")
        informError("Field repeat password is required", "repeat-password-error")
}

//sign up
$('#btn-sign-up').on('click', () => {
    checkSignUpNull()
    if($(`#first-name`).closest('.form-group').hasClass('field-error') || 
        $(`#last-name`).closest('.form-group').hasClass('field-error') || 
        $(`#phone`).closest('.form-group').hasClass('field-error') || 
        $(`#email`).closest('.form-group').hasClass('field-error') || 
        $(`#password`).closest('.form-group').hasClass('field-error') || 
        $(`#repeat-password`).closest('.form-group').hasClass('field-error'))
        return

    let firstName = $("input[name='first-name']").val()
    let lastName = $("input[name='last-name']").val()
    let phone = $("input[name='phone']").val()
    let email = $("input[name='email']").val()
    let password = $("input[name='password']").val()

    $.ajax({
        url: 'https://localhost:5001/authentication/register',
        type: 'post',
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify({
            firstName: firstName,
            lastName: lastName,
            phone: phone,
            email: email,
            password : password
        }),
        success: function(response){
            console.log(JSON.stringify(response))
        },
        error: function(data){
            alert(data.responseJSON.message)
        } 
    })

})

//sign in =========================================================
//validation - sign in
$("input[name='sign-in-phone']").on('input', () =>{
    removeValidation("sign-in-phone-error")
    if($("input[name='sign-in-phone']").val().trim().length == 0){
        error = "Field phone is required"
        informError(error, "sign-in-phone-error")
    } else {
        informValidated("sign-in-phone-error")
    }
})
$("input[name='sign-in-password']").on('input', () =>{
    removeValidation("sign-in-password-error")
    let password = $("input[name='sign-in-password']").val().trim()
    if(password.length == 0){
        error = "Field password is required"
        informError(error, "sign-in-password-error")
    }
    else{
        informValidated("sign-in-password-error")
    }
})

function checkSignInNull(){
    if($(`#sign-in-phone`).val().trim() == "")
        informError("Field phone is required", "sign-in-phone-error")
    if($(`#sign-in-password`).val().trim() == "")
        informError("Field password is required", "sign-in-password-error")
}

$('#btn-sign-in').on('click', () => {
    checkSignInNull()
    if($(`#sign-in-phone`).closest('.form-group').hasClass('field-error') || 
        $(`#sign-in-password`).closest('.form-group').hasClass('field-error'))
        return

    let signInPhone = $("input[name='sign-in-phone']").val()
    let signInPassword = $("input[name='sign-in-password']").val()

    $.ajax({
        url: 'https://localhost:5001/authentication/authenticate',
        type: 'post',
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify({
            phone: signInPhone,
            password : signInPassword
        }),
        success: function(response){
            localStorage.setItem("user_data", JSON.stringify(response))
            window.location.href = "/"
        },
        error: function(data){
            alert(data.responseJSON.message)
        } 
    })

})


//general ===========================================================
function informError(message, divError){
    if($(`#${divError}`).closest('.form-group').hasClass('field-error')) return
    let p = document.createElement('p')
    p.textContent += message
    $(`#${divError}`).closest('.form-group').addClass('field-error')
    $(`#${divError}`).closest('.form-group').children('input').attr('style', 'border-color: red !important')
    let i = document.createElement('i')
    i.classList.add('fa-solid', 'fa-xmark')
    $(`#${divError}`).append(p)
    $(`#${divError}`).append(i)
}
function informValidated(div){
    let i = document.createElement('i')
    i.classList.add('fa-solid', 'fa-check')
    $(`#${div}`).closest('.form-group').addClass('field-validated')
    $(`#${div}`).closest('.form-group').children('input').attr('style', 'border-color: green !important')
    $(`#${div}`).append(i)
}
function removeValidation(div){
    $(`#${div}`).closest('.form-group').removeClass('field-error')
    $(`#${div}`).closest('.form-group').removeClass('field-validated')
    $(`#${div}`).closest('.form-group').children('input').css('border-color', '')
    $(`#${div}`).closest('.form-group').children('input').css('border-color', '')
    $(`#${div}`).children().remove()
}
