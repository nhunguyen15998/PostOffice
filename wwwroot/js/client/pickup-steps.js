//service
function onService(){
    $('#sender-info').addClass('step-hidden')
    $('#receiver-info').addClass('step-hidden')
    $('#payment-process').addClass('step-hidden')
    $('#purchase-product').addClass('step-hidden')
    if($('#select-service').hasClass('step-hidden'))
        $('#select-service').removeClass('step-hidden')
    if($('#right-image').hasClass('step-hidden'))
        $('#right-image').removeClass('step-hidden')
    if(!$('#processing-step-1').hasClass('activated-step')){
        $('#processing-step-1').addClass('activated-step')
    }
    $('#processing-step-2').removeClass('activated-step')
    $('#processing-step-3').removeClass('activated-step')
    $('#processing-step-4').removeClass('activated-step')
    $('#processing-step-5').removeClass('activated-step')
}
$('#processing-step-1').addClass('activated-step')
onService()

//service -> product
function onProduct(){
    $('#select-service').addClass('step-hidden')
    $('#sender-info').addClass('step-hidden')
    $('#receiver-info').addClass('step-hidden')
    $('#payment-process').addClass('step-hidden')
    $('#right-image').addClass('step-hidden')
    if($('#purchase-product').hasClass('step-hidden'))
        $('#purchase-product').removeClass('step-hidden')
    if(!$('#processing-step-2').hasClass('activated-step')){
        $('#processing-step-2').addClass('activated-step')
    }
    $('#processing-step-3').removeClass('activated-step')
    $('#processing-step-4').removeClass('activated-step')
    $('#processing-step-5').removeClass('activated-step')
}
$('#btn-service-next').on('click', () => {
    onProduct()
})

//product -> sender
function onSender(){
    $('#select-service').addClass('step-hidden')
    $('#purchase-product').addClass('step-hidden')
    $('#receiver-info').addClass('step-hidden')
    $('#payment-process').addClass('step-hidden')
    if($('#sender-info').hasClass('step-hidden'))
        $('#sender-info').removeClass('step-hidden')
    if($('#right-image').hasClass('step-hidden'))
        $('#right-image').removeClass('step-hidden')
    if(!$('#processing-step-3').hasClass('activated-step')){
        $('#processing-step-3').addClass('activated-step')
    }
    $('#processing-step-4').removeClass('activated-step')
    $('#processing-step-5').removeClass('activated-step')
}
$('#btn-product-next').on('click', () => {
    onSender()
})
$('#btn-product-back').on('click', () => {
    onService()
})

//sender -> receiver
function onReceiver(){
    $('#select-service').addClass('step-hidden')
    $('#purchase-product').addClass('step-hidden')
    $('#sender-info').addClass('step-hidden')
    $('#payment-process').addClass('step-hidden')
    if($('#receiver-info').hasClass('step-hidden'))
        $('#receiver-info').removeClass('step-hidden')
    if($('#right-image').hasClass('step-hidden'))
        $('#right-image').removeClass('step-hidden')
    if(!$('#processing-step-4').hasClass('activated-step')){
        $('#processing-step-4').addClass('activated-step')
    }
    $('#processing-step-5').removeClass('activated-step')
}
$('#btn-sender-next').on('click', () => {
    onReceiver()
})
$('#btn-sender-back').on('click', () => {
    onProduct()
})

//receiver ->  payment
function onPayment(){
    $('#select-service').addClass('step-hidden')
    $('#purchase-product').addClass('step-hidden')
    $('#sender-info').addClass('step-hidden')
    $('#receiver-info').addClass('step-hidden')
    $('#right-image').addClass('step-hidden')
    if($('#payment-process').hasClass('step-hidden'))
        $('#payment-process').removeClass('step-hidden')
    $('#processing-step-5').addClass('activated-step')
}

$('#btn-receiver-next').on('click', () => {
    onPayment()
})
$('#btn-receiver-back').on('click', () => {
    onSender()
})

//payment
$('#btn-payment-back').on('click', () => {
    onReceiver()
})

//=======================service======================
//select pickup or branch
$('#pickup').prop('checked', true)
$('#at-branch').prop('checked', false)

$('#pickup').on('click', () => {
    $('#at-branch').prop('checked', false)
    if($('#pickup').is(':checked')){
        $('#sending-date-label').text("Pickup date")
    }
})

$('#at-branch').on('click', () => {
    $('#pickup').prop('checked', false)
    if($('#at-branch').is(':checked')){
        $('#sending-date-label').text("Branch arrival at")
    }
})

//=======================sender======================
$('#chb-company').prop('checked', false)
$('#company-info').addClass('step-hidden')

$('#chb-company').on('click', () => {
    if($('#chb-company').is(':checked')){
        $('#company-info').removeClass('step-hidden')
    } else {
        if(!$('#company-info').hasClass('step-hidden'))
            $('#company-info').addClass('step-hidden')
    }
})

//=======================receiver======================
let index = 1
let records = document.getElementById("add-person-info").childElementCount - 1 ?? 0
//photo
function readFile(input, index) {
    if (input.files) {
        $(`#receiver-photo-${index}`).removeClass('step-hidden')
        let count = 1
        let i = `<i class="fa-solid fa-circle-xmark"></i>`
        $(`#photo-scroll-${index}`).empty()
        Array.from(input.files).forEach(file => {
            var reader = new FileReader()
            //div
            var div = document.createElement('div')
            div.classList.add('col-sm-2', 'justify-content-center',  'p-0')  
            div.style.position = "relative" 
            div.id = `div-img-${index}-`+ count
            $(`#photo-scroll-${index}`).append(div)
            //btn
            var btn = document.createElement('button')
            btn.classList.add('btn')
            btn.style.position = "absolute"
            btn.style.left = "65px"
            btn.style.top = "-5px"
            btn.id = `btn-rm-photo-${index}-` + count
            btn.addEventListener('click', () => {
                removePhoto(div.id, index)
            })
            $(`#photo-scroll-${index}`).children('#' + div.id).append(btn) 
            $(`#${btn.id}`).append(i)  
            //img
            var img = document.createElement('img')
            $(`#photo-scroll-${index}`).children('#' + div.id).append(img)
            img.width = 100
            img.height = 100
            img.id = `show-img-${index}-`+ count
            var image = document.getElementById(img.id)
            reader.onload = () => {
                image.src = reader.result
            }
            reader.readAsDataURL(file)
            count++
        })
    }
}

// Change Event to Read file content from File input
$(document).on('change', '#photos-1', function () { 
    readFile(document.getElementById('photos-1'), index)
})
function changePhoto(index){
    readFile(document.getElementById(`photos-${index}`), index)
}

//remove photo 
$('#receiver-photo-1').addClass('step-hidden')

function removePhoto(id, index){    
    $(`#photo-scroll-${index}`).children(`#${id}`).remove()
    let input = document.getElementById(`photos-${index}`)
    let fileListArr = [...input.files]
    fileListArr.splice(id - 1, 1)
    let dataTransfer = new DataTransfer()
    for (let file of fileListArr) { 
        dataTransfer.items.add(file) 
    }
    document.getElementById(`photos-${index}`).files = dataTransfer.files
    if(!document.querySelector(`#photo-scroll-${index}`).hasChildNodes()){
        document.getElementById(`photos-${index}`).value = ""
    }
    if(document.getElementById(`photos-${index}`).files.length == 0){
        $(`#add-person-info-${index}`).children(`#receiver-photo-${index}`).addClass('step-hidden')
    }
}

function receiverInfo(index){
    return  `<div class="row">
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="wpcf7-form-control-wrap"><input
                            type="text"
                            name="receiver-first-name-${index}"
                            class="wpcf7-form-control wpcf7-text"
                            aria-invalid="false"
                            placeholder="First name">
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="wpcf7-form-control-wrap"><input
                            type="text"
                            name="receiver-last-name-${index}"
                            class="wpcf7-form-control wpcf7-text"
                            aria-invalid="false"
                            placeholder="Last name">
                    </span>
                </div>
            </div>
        </div>
    </div>
    </div>
    <div class="row">
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="wpcf7-form-control-wrap"><input
                            type="text" name="to-phone-${index}"
                            class="wpcf7-form-control wpcf7-text"
                            aria-invalid="false"
                            placeholder="Phone">
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="wpcf7-form-control-wrap"><input
                            type="text" name="to-email-${index}"
                            class="wpcf7-form-control wpcf7-text"
                            aria-invalid="false"
                            placeholder="Email">
                    </span>
                </div>
            </div>
        </div>
    </div>
    </div>
    <div class="row">
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="wpcf7-form-control-wrap"><input
                            type="text"
                            name="to-address-${index}"
                            class="wpcf7-form-control wpcf7-text"
                            aria-invalid="false"
                            placeholder="Address">
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="wpcf7-form-control-wrap">
                        <select name="to-ward-${index}"
                            id="to-ward-${index}"
                            data-placeholder="Select ward…"
                            tabindex="-1"
                            aria-hidden="true">
                            <option value="">Select
                                ward…
                            </option>
                            <option value="EH">Western
                                Sahara
                            </option>
                            <option value="YE">Yemen
                            </option>
                            <option value="ZM">Zambia
                            </option>
                            <option value="ZW">Zimbabwe
                            </option>
                        </select>
                    </span>
                </div>
            </div>
        </div>
    </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="row">
                <div class="col-sm-6">
                    <div class="input-group">
                        <span
                            class="wpcf7-form-control-wrap">
                            <select name="to-district-${index}"
                                id="to-district-${index}"
                                data-placeholder="Select district…"
                                tabindex="-1"
                                aria-hidden="true">
                                <option value="">Select
                                    district…
                                </option>
                                <option value="EH">Western
                                    Sahara
                                </option>
                                <option value="YE">Yemen
                                </option>
                                <option value="ZM">Zambia
                                </option>
                                <option value="ZW">Zimbabwe
                                </option>
                            </select>
                        </span>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="input-group">
                        <span
                            class="wpcf7-form-control-wrap">
                            <select name="to-province-${index}"
                                id="to-province-${index}"
                                data-placeholder="Select province…"
                                tabindex="-1"
                                aria-hidden="true">
                                <option value="">Select
                                    province…
                                </option>
                                <option value="EH">Western
                                    Sahara
                                </option>
                                <option value="YE">Yemen
                                </option>
                                <option value="ZM">Zambia
                                </option>
                                <option value="ZW">Zimbabwe
                                </option>
                            </select>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row row-btn justify-content-between" style="padding: 0 12px;">
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span class="wpcf7-form-control-wrap"><input
                        type="text" name="pin-code-${index}"
                        class="wpcf7-form-control wpcf7-text"
                        aria-invalid="false"
                        placeholder="Pin code">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span class="wpcf7-form-control-wrap"><input
                        type="text" name="length-${index}"
                        class="wpcf7-form-control wpcf7-text"
                        aria-invalid="false"
                        placeholder="Weight">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span
                    class="wpcf7-form-control-wrap"><input
                        type="text" name="length-${index}"
                        class="wpcf7-form-control wpcf7-text"
                        aria-invalid="false"
                        placeholder="Length">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span
                    class="wpcf7-form-control-wrap"><input
                        type="text" name="width-${index}"
                        class="wpcf7-form-control wpcf7-text"
                        aria-invalid="false"
                        placeholder="Width">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span
                    class="wpcf7-form-control-wrap"><input
                        type="text" name="height-${index}"
                        class="wpcf7-form-control wpcf7-text"
                        aria-invalid="false"
                        placeholder="Height">
                </span>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="align-items-center col-sm-6 d-flex">
            <div class="input-group"
                style="margin-bottom: 0 !important;">
                <label for="pickup"
                    style="font-size: 14px;">Add some photos
                    of pickup stuff</label>
                <span class="wpcf7-form-control-wrap">
                    <input type="file" name="photos-${index}"
                        multiple style="font-size: 13px;"
                        id="photos-${index}" onchange="changePhoto(${index})">
                </span>
            </div>
        </div>
    </div>
    <div class="m-0 mb-5 step-hidden" id="receiver-photo-${index}" style="background-color: #ffdc39; padding: 10px; overflow: scroll hidden;">
        <div id="photo-scroll-${index}"
            class="align-items-center d-flex p-0">

        </div>
    </div>`
}
let btnBack = `<input type="button" value="BACK" id="btn-receiver-back" class="mr-3">`
let btnNext = `<input type="button" value="NEXT" id="btn-receiver-next">`
function loadBtnDelete(index){
    return `<div class="col-sm-6">
                    <div class="d-flex align-items-center" id="div-remove-record-${index}">
                    </div>
                </div>`
}

//btnadd
let btnAddMorePerson = document.createElement('button')
btnAddMorePerson.type = "button"
btnAddMorePerson.classList.add('align-items-center', 'btn', 'd-flex')
btnAddMorePerson.id = "btn-add-more-person"
btnAddMorePerson.style.backgroundColor = "#ffcd39"
btnAddMorePerson.style.borderRadius = "50%"
btnAddMorePerson.style.height = "45px"
let iconAdd = document.createElement('i')
iconAdd.classList.add('fa-solid', 'fa-person-circle-plus')
btnAddMorePerson.append(iconAdd)

btnAddMorePerson.addEventListener('click', () => {
    index++
    records++
    addMorePerson(`add-person-info-${index}`, index)
    if(index > 2){
        //btndelete
        let iconDelete = document.createElement('i')
        iconDelete.classList.add('fa-solid', 'fa-trash-can')
        let btnRemoveRecord = document.createElement('button')
        btnRemoveRecord.type = "button"
        btnRemoveRecord.classList.add('align-items-center', 'btn', 'btn-danger', 'd-flex', 'justify-content-center')
        btnRemoveRecord.style.borderRadius = "50%"
        btnRemoveRecord.style.width = "45px"
        btnRemoveRecord.style.height = "45px"
        btnRemoveRecord.append(iconDelete)

        let divRemove = loadBtnDelete(index)
        $(`#add-person-info-${index}`).children('.row-btn').append(divRemove)
        btnRemoveRecord.id = `btn-remove-record-${index}`
        $(`#div-remove-record-${index}`).append(btnRemoveRecord)
        btnRemoveRecord.addEventListener('click', () => {
            $(`#${btnRemoveRecord.id}`).closest('.each').remove()
            $('#div-btn-add').children('p').remove()
            let records = document.getElementById("add-person-info").childElementCount - 1
            document.getElementById('div-btn-add').insertAdjacentHTML('afterbegin', `<p class="mb-0 mr-4">Total receivers: <span>${records}</span></p>`)
        })
    }
})

$('#single-person').prop('checked', true)

$('#multiple-people').prop('checked', false)

$('#single-person').on('click', () => {
    index = 2
    $('#multiple-people').prop('checked', false)
    $('#single-person').prop('checked', true)
    if(!$('#btn-add-more-person').closest('.d-flex').hasClass('step-hidden')){
        $('#btn-add-more-person').closest('.d-flex').addClass('step-hidden')
    }
    if($('#add-person-info').find('#add-person-info-2').length){
        let index = 1
        $('#add-person-info').children('div').remove()
        loadReceiverForm(`add-person-info-${index}`, "")
        $(`#add-person-info-1`).children('hr').remove()
    }
})

$('#multiple-people').on('click', () => {
    index = 2
    $('#single-person').prop('checked', false)
    $('#multiple-people').prop('checked', true)
    if($('#btn-multiple').hasClass('step-hidden')){
        $('#btn-multiple').removeClass('step-hidden')
    }
    if($('#add-person-info').find('#add-person-info-2').length){
        $('#add-person-info').children('#add-person-info-2').remove()
    }
    addMorePerson("add-person-info-2", 2, 2)
    if($('#btn-add-more-person').hasClass('step-hidden')){
        $('#btn-add-more-person').removeClass('step-hidden')
    }
})

function loadReceiverForm(divId, index){
    var div = document.createElement('div')
    div.classList.add('each')
    div.id = divId
    $('#add-person-info').append(div)
    let receiver = receiverInfo(index)
    $(`#${divId}`).append(`<hr id="hr-${index}" style="margin-bottom: 70px;"/>`)
    $(`#${divId}`).append(receiver)
}

function addMorePerson(divId, index){
    $('#add-person-info').children('#div-btn-add').remove()
    loadReceiverForm(divId, index)
    var divBtn = document.createElement('div')
    divBtn.classList.add('d-flex', 'mb-5', 'align-items-center')
    divBtn.id = "div-btn-add"
    $('#add-person-info').append(divBtn)
    let records = document.getElementById("add-person-info").childElementCount - 1
    document.getElementById('div-btn-add').insertAdjacentHTML('afterbegin', `<p class="mb-0 mr-4">Total receivers: <span>${records}</span></p>`)
    document.getElementById('div-btn-add').appendChild(btnAddMorePerson)
}

//=======================receiver======================
