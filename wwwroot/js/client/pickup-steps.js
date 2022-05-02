//service
function onService() {
  $("#sender-info").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  if ($("#select-service").hasClass("step-hidden"))
    $("#select-service").removeClass("step-hidden");
  if ($("#right-image").hasClass("step-hidden"))
    $("#right-image").removeClass("step-hidden");
  if (!$("#processing-step-1").hasClass("activated-step")) {
    $("#processing-step-1").addClass("activated-step");
  }
  $("#processing-step-2").removeClass("activated-step");
  $("#processing-step-3").removeClass("activated-step");
  $("#processing-step-4").removeClass("activated-step");
  $("#processing-step-5").removeClass("activated-step");
}
$("#processing-step-1").addClass("activated-step");
onService()

//product -> sender
function onSender() {
  $("#select-service").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  if ($("#sender-info").hasClass("step-hidden"))
    $("#sender-info").removeClass("step-hidden");
  if ($("#right-image").hasClass("step-hidden"))
    $("#right-image").removeClass("step-hidden");
  if (!$("#processing-step-2").hasClass("activated-step")) {
    $("#processing-step-2").addClass("activated-step");
  }
  $("#processing-step-3").removeClass("activated-step");
  $("#processing-step-4").removeClass("activated-step");
  $("#processing-step-5").removeClass("activated-step");
}
$("#btn-service-next").on("click", () => {
  onSender()
})

//sender -> receiver
function onReceiver() {
  $("#select-service").addClass("step-hidden");
  $("#sender-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  if ($("#receiver-info").hasClass("step-hidden"))
    $("#receiver-info").removeClass("step-hidden");
  if ($("#right-image").hasClass("step-hidden"))
    $("#right-image").removeClass("step-hidden");
  if (!$("#processing-step-3").hasClass("activated-step")) {
    $("#processing-step-3").addClass("activated-step");
  }
  $("#processing-step-4").removeClass("activated-step")
  $("#processing-step-5").removeClass("activated-step");
}
$("#btn-sender-next").on("click", () => {
  onReceiver();
});
$("#btn-sender-back").on("click", () => {
  onService()
});

//receiver ->  payment
function onPayment() {
  $("#select-service").addClass("step-hidden");
  $("#sender-info").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#right-image").addClass("step-hidden");
  if ($("#payment-process").hasClass("step-hidden"))
    $("#payment-process").removeClass("step-hidden")
  $("#processing-step-4").addClass("activated-step")
  reviewService()
  reviewSender()
  reviewReceiver()
  reviewProduct()
}

$("#btn-receiver-next").on("click", () => {
  onPayment();
});
$("#btn-receiver-back").on("click", () => {
  onSender();
});

//payment
$("#btn-payment-back").on("click", () => {
  onReceiver();
})
//payment -> complete
function onComplete() {
  $("#select-service").addClass("step-hidden");
  $("#sender-info").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  $("#right-image").addClass("step-hidden");
  $("#processing-step-5").addClass("activated-step");
}

//=======================service======================
//select pickup or branch
$("#pickup").prop("checked", true);
$("#at-branch").prop("checked", false);

$("#pickup").on("click", () => {
  $("#at-branch").prop("checked", false);
  if ($("#pickup").is(":checked")) {
    $("#sending-date-label").text("Pickup date");
  }
});

$("#at-branch").on("click", () => {
  $("#pickup").prop("checked", false);
  if ($("#at-branch").is(":checked")) {
    $("#sending-date-label").text("Branch arrival at");
  }
});

//=======================sender======================
$("#chb-company").prop("checked", false);
$("#company-info").addClass("step-hidden");

$("#chb-company").on("click", () => {
  if ($("#chb-company").is(":checked")) {
    $("#company-info").removeClass("step-hidden");
  } else {
    if (!$("#company-info").hasClass("step-hidden"))
      $("#company-info").addClass("step-hidden");
  }
});

//=======================receiver======================
let index = 1;
let records = document.getElementById("add-person-info").childElementCount - 1 ?? 0;
//photo
function readFile(input, index) {
  if (input.files) {
    $(`#receiver-photo-${index}`).removeClass("step-hidden");
    let count = 1;
    let i = `<i class="fa-solid fa-circle-xmark"></i>`;
    $(`#photo-scroll-${index}`).empty();
    Array.from(input.files).forEach((file) => {
      var reader = new FileReader();
      //div
      var div = document.createElement("div");
      div.classList.add("col-sm-2", "justify-content-center", "p-0");
      div.id = `div-img-${index}-` + count;
      $(`#photo-scroll-${index}`).append(div);
      //btn
      var btn = document.createElement("button");
      btn.classList.add("btn");
      btn.style.position = "absolute";
      btn.style.left = "65px";
      btn.style.top = "-5px";
      btn.id = `btn-rm-photo-${index}-` + count;
      btn.addEventListener("click", () => {
        removePhoto(div.id, index);
      });
      $(`#photo-scroll-${index}`)
        .children("#" + div.id)
        .append(btn);
      $(`#${btn.id}`).append(i);
      //img
      var img = document.createElement("img");
      $(`#photo-scroll-${index}`)
        .children("#" + div.id)
        .append(img);
      img.width = 100;
      img.height = 100;
      img.id = `show-img-${index}-` + count;
      var image = document.getElementById(img.id);
      reader.onload = () => {
        image.src = reader.result;
      };
      reader.readAsDataURL(file);
      count++;
    });
  }
}

// Change Event to Read file content from File input
$(document).on("change", "#photos-1", function () {
  readFile(document.getElementById("photos-1"), 1);
});
function changePhoto(index) {
  readFile(document.getElementById(`photos-${index}`), index);
}

//remove photo
$("#receiver-photo-1").addClass("step-hidden");

function removePhoto(id, index) {
  $(`#photo-scroll-${index}`).children(`#${id}`).remove();
  let input = document.getElementById(`photos-${index}`);
  let fileListArr = [...input.files];
  fileListArr.splice(id - 1, 1);
  let dataTransfer = new DataTransfer();
  for (let file of fileListArr) {
    dataTransfer.items.add(file);
  }
  document.getElementById(`photos-${index}`).files = dataTransfer.files;
  if (!document.querySelector(`#photo-scroll-${index}`).hasChildNodes()) {
    document.getElementById(`photos-${index}`).value = "";
  }
  if (document.getElementById(`photos-${index}`).files.length == 0) {
    $(`#add-person-info-${index}`)
      .children(`#receiver-photo-${index}`)
      .addClass("step-hidden");
  }
}

let _modalIndex = 1
function receiverInfo(index) {
  getReceiverProvinces(index)
  let modal = `<div class="modal fade" id='receiver-add-product-${index}' tabindex="-1" aria-labelledby='receiver-add-product-${index}-label'
                aria-hidden="true">
                <div class="modal-dialog modal-dialog modal-dialog-centered" style="max-width: fit-content;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id='receiver-add-product-${index}-label'>PURCHASE PRODUCTS</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body" style="overflow: hidden scroll;height: 500px;">
                            <!--product-->
                            <div id="purchase-product" class="container mt-5" style="max-width: 95%;">
                                <div class="row mb-3">
                                    <div class="col-sm-3">
                                        <div class="input-group">
                                            <div
                                                style="border: 1px solid rgba(119, 119, 119, 0.2);line-height: 53px;">
                                                <div class="dropdown" id="product-cate-list-${index}" style="height: 51px;">
                                                    <a class="btn dropdown-toggle tg-service" href="#" role="button"
                                                        id='select-product-cate-${index}' data-bs-toggle="dropdown"
                                                        aria-expanded="false" style="height: 100%; width: 100%;">
                                                        <button
                                                            style="background-color: transparent;color: #111;width: 100%;text-align: left;font-size: 13px;"
                                                            class="btn-sm">Select product category</button>
                                                    </a>
                                                    <ul class="dropdown-menu p-0"
                                                        aria-labelledby='select-product-cate-${index}'
                                                        style="height: 142px; width: 100%; border-radius: 0px; line-height: 40px; overflow: hidden;">
                                                        <li style="padding: 0 20px;font-size: 14px;">--Select
                                                            product category</li>
                                                        <div style="overflow: hidden scroll;height: 100px;"></div>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-9" style="">
                                        <div class=""
                                            style="border: 1px solid rgba(119, 119, 119, 0.2);line-height: 53px;">
                                            <div class="dropdown" id='product-list-${index}' style="height: 51px;">
                                                <a class="btn dropdown-toggle" href="#" role="button"
                                                    id='select-product-${index}' data-bs-toggle="dropdown"
                                                    aria-expanded="false">
                                                    <input type="search" placeholder="Search product…"
                                                        style="border: none;padding: 0;">
                                                </a>
                                                <ul class="dropdown-menu" aria-labelledby='select-product-${index}'
                                                    style="overflow: hidden; height: 250px; line-height: 40px; width:100%;"
                                                    data-popper-placement="bottom-start">
                                                    <li style="padding: 0 20px;font-size: 14px;">--Select product
                                                    </li>
                                                    <div style="overflow: hidden scroll;height: 200px;font-size: 13px;"
                                                        id='div-product-${index}'>

                                                    </div>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="postalservice">
                                    <div class="postalservice-notices-wrapper"></div>
                                    <form class="postalservice-cart-form">
                                        <table
                                            class="shop_table shop_table_responsive cart postalservice-cart-form__contents"
                                            cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th class="product-remove">&nbsp;</th>
                                                    <th class="product-thumbnail">&nbsp;</th>
                                                    <th class="product-name">Product</th>
                                                    <th class="product-name">Attribute</th>
                                                    <th class="product-price">Price</th>
                                                    <th class="product-quantity">Quantity</th>
                                                    <th class="product-subtotal">Subtotal</th>
                                                </tr>
                                            </thead>
                                            <tbody id='tbody-product-${index}' data-rows="0">
                                                <tr id='tbody-default-${index}'>
                                                    <td colspan="7" class="text-center">Empty cart</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </form>
                                    <div class="cart-collaterals">
                                        <div class="cart_totals ">
                                            <h5>Cart totals</h5>
                                            <table cellspacing="0" class="shop_table shop_table_responsive">
                                                <tbody id='tbody-total-cart-${index}'>
                                                    <tr class="cart-subtotal" data-subtotal-product="0">
                                                        <th>Subtotal</th>
                                                        <td data-title="Subtotal">
                                                            <span class="postalservice-Price-amount amount"></span>
                                                        </td>
                                                    </tr>
                                                    <tr class="order-total" data-total-product="0">
                                                        <th>Total</th>
                                                        <td data-title="Total">
                                                            <span class="postalservice-Price-amount amount"
                                                                style="font-weight: bold;"></span>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-sm" style="background-color:#ffdc39;" data-bs-dismiss="modal">Done</button>
                        </div>
                    </div>
                </div>
              </div>`
  document.querySelector('#page').insertAdjacentHTML('afterbegin', modal)
  _modalIndex = index
  getProductCateList(0)
  getProductByPCate(0)
  return `<div class="row">
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="postoffice-form-control-wrap"><input
                            type="text"
                            name="receiver-first-name-${index}"
                            class="postoffice-form-control postoffice-text"
                            aria-invalid="false"
                            placeholder="First name">
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="postoffice-form-control-wrap"><input
                            type="text"
                            name="receiver-last-name-${index}"
                            class="postoffice-form-control postoffice-text"
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
                        class="postoffice-form-control-wrap"><input
                            type="text" name="to-phone-${index}"
                            class="postoffice-form-control postoffice-text"
                            aria-invalid="false"
                            placeholder="Phone">
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="input-group">
                    <span
                        class="postoffice-form-control-wrap"><input
                            type="text" name="to-email-${index}"
                            class="postoffice-form-control postoffice-text"
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
                        class="postoffice-form-control-wrap"><input
                            type="text"
                            name="to-address-${index}"
                            class="postoffice-form-control postoffice-text"
                            aria-invalid="false"
                            placeholder="Address">
                    </span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="input-group">
                  <div style="border: 1px solid rgba(119, 119, 119, 0.2);line-height: 53px;">
                    <div class="dropdown dropdown-receiver" id="receiver-province-${index}"
                      style="height: 51px;">
                      <a class="btn dropdown-toggle"
                        href="#" role="button"
                        id="select-receiver-province-${index}"
                        data-bs-toggle="dropdown"
                        aria-expanded="false"
                        style="height: 100%; width: 100%;">
                        <button style="background-color: transparent;color: #111;width: 100%;text-align: left;font-size: 13px;"
                          class="btn-sm" data-province="">Select province</button>
                      </a>
                      <ul class="dropdown-menu p-0"
                        aria-labelledby="select-receiver-province-${index}"
                        style="height: 142px; width: 100%; border-radius: 0px; line-height: 40px; overflow: hidden;">
                        <li style="padding: 0 20px;font-size: 14px;">--Select province</li>
                        <div style="overflow: hidden scroll;height: 100px;"> </div>
                      </ul>
                    </div>
                  </div>
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
                      <div style="border: 1px solid rgba(119, 119, 119, 0.2);line-height: 53px;">
                        <div class="dropdown dropdown-receiver" id="receiver-district-${index}"
                          style="height: 51px;">
                          <a class="btn dropdown-toggle"
                            href="#" role="button"
                            id="select-receiver-district-${index}"
                            data-bs-toggle="dropdown"
                            aria-expanded="false"
                            style="height: 100%; width: 100%;">
                            <button style="background-color: transparent;color: #111;width: 100%;text-align: left;font-size: 13px;"
                              class="btn-sm" data-district="">Select district</button>
                          </a>
                          <ul class="dropdown-menu p-0"
                            aria-labelledby="select-receiver-district-${index}"
                            style="height: 142px; width: 100%; border-radius: 0px; line-height: 40px; overflow: hidden;">
                            <li style="padding: 0 20px;font-size: 14px;">--Select district</li>
                            <div style="overflow: hidden scroll;height: 100px;"> </div>
                          </ul>
                        </div>
                      </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="input-group">
                      <div style="border: 1px solid rgba(119, 119, 119, 0.2);line-height: 53px;">
                        <div class="dropdown dropdown-receiver" id="receiver-ward-${index}"
                          style="height: 51px;">
                          <a class="btn dropdown-toggle"
                            href="#" role="button"
                            id="select-receiver-ward-${index}"
                            data-bs-toggle="dropdown"
                            aria-expanded="false"
                            style="height: 100%; width: 100%;">
                            <button style="background-color: transparent;color: #111;width: 100%;text-align: left;font-size: 13px;"
                              class="btn-sm" data-ward="">Select ward</button>
                          </a>
                          <ul class="dropdown-menu p-0"
                            aria-labelledby="select-receiver-ward-${index}"
                            style="height: 142px; width: 100%; border-radius: 0px; line-height: 40px; overflow: hidden;">
                            <li style="padding: 0 20px;font-size: 14px;">--Select ward</li>
                            <div style="overflow: hidden scroll;height: 100px;"> </div>
                          </ul>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row row-btn justify-content-between" style="padding: 0 12px;">
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span class="postoffice-form-control-wrap"><input
                        type="text" name="pin-code-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Pin code">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span class="postoffice-form-control-wrap"><input
                        type="text" name="weight-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Weight">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span
                    class="postoffice-form-control-wrap"><input
                        type="text" name="length-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Length">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span
                    class="postoffice-form-control-wrap"><input
                        type="text" name="width-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Width">
                </span>
            </div>
        </div>
        <div class="col-sm-2 p-0">
            <div class="input-group">
                <span
                    class="postoffice-form-control-wrap"><input
                        type="text" name="height-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Height">
                </span>
            </div>
        </div>
    </div>
    <!--Parcel detail-->
    <div class="row">
        <div class="d-flex" style="padding: 0 15px;">
            <label for="pickup"
                style="font-size: 14px;"
                class="mr-2">Add parcel
                details</label>
            <div class="d-flex">
                <button type="button"
                    class="align-items-center btn d-flex justify-content-center p-0"
                    id="btn-add-more-parcel-${index}" onclick="addMoreParcel(${index})"
                    style=" border-radius: 50%; height: 20px;width: 20px;background-color: rgb(255, 205, 57);"><i
                        class="fa-solid fa-plus"
                        style="font-size: 10px;"></i></button>
            </div>
        </div>
        <div class="col-sm-12" id="parcel-detail-${index}">
            <div class="row" id="details-${index}-1">
                <div class="col-sm-7">
                    <div class="input-group">
                        <span
                            class="postoffice-form-control-wrap"><input
                                type="text"
                                name="name-${index}-1"
                                class="postoffice-form-control postoffice-text"
                                aria-invalid="false"
                                placeholder="Name">
                        </span>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span
                            class="postoffice-form-control-wrap"><input
                                type="text"
                                name="qty-${index}-1"
                                class="postoffice-form-control postoffice-text"
                                aria-invalid="false"
                                placeholder="Qty">
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Notes-->
    <div class="row">
        <label for="notes" style="font-size: 14px;"
            class="col-sm-9">Notes</label>
        <label for="amount" style="font-size: 14px;"
            class="col-sm-3">Amount
            collected</label>
    </div>
    <div class="justify-content-between row">
        <div class="col-sm-9">
            <div class="input-group">
                <span
                    class="postoffice-form-control-wrap"><textarea
                        type="text" name="notes-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Write some notes"
                        style="font-size: 12px; height: 53px;"
                        rows="1"></textarea>
                </span>
            </div>
        </div>
        <div class="col-sm-3">
            <div class="input-group">
                <span
                    class="postoffice-form-control-wrap"><input
                        type="text" name="amount-${index}"
                        class="postoffice-form-control postoffice-text"
                        aria-invalid="false"
                        placeholder="Up to 3000k">
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
                <span class="postoffice-form-control-wrap">
                    <input type="file" name="photos-${index}"
                        multiple style="font-size: 13px;"
                        id="photos-${index}" onchange="changePhoto(${index})">
                </span>
            </div>
        </div>
        <div class="align-items-center col-sm-6 d-flex">
          <div class="input-group"
            style="margin-bottom: 0 !important;">
            <label for="pickup"
              style="font-size: 14px;">Add products such as containers, etc. to this parcel</label>
            <div style="padding: 10px 0;">
              <button class="btn mr-1" style="background-color: #ffdc39;height: 30px;font-size: 12px;"  type="button"
                id="btn-receiver-add-product-${index}" data-bs-toggle="modal" data-bs-target="#receiver-add-product-${index}"
                onclick="setModalIndex(${index})">
                <span></span>
                <i class="fa-solid fa-basket-shopping"></i>
              </button>
              <button class="btn btn-danger" style="height: 30px;font-size: 12px;" type="button"
                id="btn-receiver-clear-product-${index}" onclick="clearReceiverProducts(${index})">
                <i class="fa-solid fa-trash-can"></i>
              </button>
            </div>
          </div>
        </div>
    </div>
    <div class="m-0 mb-5 step-hidden" id="receiver-photo-${index}" style="background-color: #ffdc39; padding: 10px; overflow: scroll hidden;">
        <div id="photo-scroll-${index}"
            class="align-items-center d-flex p-0">

        </div>
    </div>`
}

let btnBack = `<input type="button" value="BACK" id="btn-receiver-back" class="mr-3">`;
let btnNext = `<input type="button" value="NEXT" id="btn-receiver-next">`;
function loadBtnDelete(index) {
  return `<div class="d-flex align-items-center" id="div-remove-record-${index}" 
                style="position: absolute;top: 85px;left: -55px; width:7%;"></div>`;
}

//btnadd
let btnAddMorePerson = document.createElement("button");
btnAddMorePerson.type = "button";
btnAddMorePerson.classList.add("align-items-center", "btn", "d-flex");
btnAddMorePerson.id = "btn-add-more-person";
btnAddMorePerson.style.backgroundColor = "#ffcd39";
btnAddMorePerson.style.borderRadius = "50%";
btnAddMorePerson.style.height = "45px";
let iconAdd = document.createElement("i");
iconAdd.classList.add("fa-solid", "fa-person-circle-plus");
btnAddMorePerson.append(iconAdd);

btnAddMorePerson.addEventListener("click", () => {
  if(parseInt($('#div-btn-add').find('span').text()) == 5){
    return toastAlert('Receiver quantity', `Maximum receivers is 5`, info, 3000)
  }
  index++;
  records++;
  addMorePerson(`add-person-info-${index}`, index);
  if (index > 2) {
    //btndelete
    let iconDelete = document.createElement("i");
    iconDelete.classList.add("fa-solid", "fa-xmark");
    let btnRemoveRecord = document.createElement("button");
    btnRemoveRecord.type = "button";
    btnRemoveRecord.classList.add(
      "align-items-center",
      "btn",
      "btn-secondary",
      "d-flex",
      "justify-content-center"
    );
    btnRemoveRecord.style.borderRadius = "50%";
    btnRemoveRecord.style.width = "25px";
    btnRemoveRecord.style.height = "25px";
    btnRemoveRecord.append(iconDelete);

    let divRemove = loadBtnDelete(index);
    $(`#add-person-info-${index}`).children(".row-btn").append(divRemove);
    btnRemoveRecord.id = `btn-remove-record-${index}`;
    $(`#div-remove-record-${index}`).append(btnRemoveRecord);
    btnRemoveRecord.addEventListener("click", () => {
      $(`#${btnRemoveRecord.id}`).closest(".each").remove();
      $("#div-btn-add").children("p").remove();
      let records =
        document.getElementById("add-person-info").childElementCount - 1;
      document
        .getElementById("div-btn-add")
        .insertAdjacentHTML(
          "afterbegin",
          `<p class="mb-0 mr-4">Total receivers: <span>${records}</span></p>`
        )
      $('#page').children(`#receiver-add-product-${_modalIndex}`).remove()
    })
  }
});

$("#single-person").prop("checked", true);

$("#multiple-people").prop("checked", false);

$("#single-person").on("click", () => {
  index = 2;
  $("#multiple-people").prop("checked", false);
  $("#single-person").prop("checked", true);
  if (!$("#btn-add-more-person").closest(".d-flex").hasClass("step-hidden")) {
    $("#btn-add-more-person").closest(".d-flex").addClass("step-hidden");
  }
  if ($("#add-person-info").find("#add-person-info-2").length) {
    let index = 1;
    $("#add-person-info").children("div").remove();
    loadReceiverForm(`add-person-info-${index}`, index);
    $(`#add-person-info-1`).children("hr").remove();
  }
});

$("#multiple-people").on("click", () => {
  index = 2;
  $("#single-person").prop("checked", false);
  $("#multiple-people").prop("checked", true);
  if ($("#btn-multiple").hasClass("step-hidden")) {
    $("#btn-multiple").removeClass("step-hidden");
  }
  if ($("#add-person-info").find("#add-person-info-2").length) {
    $("#add-person-info").children("#add-person-info-2").remove();
  }
  addMorePerson("add-person-info-2", 2, 2);
  if ($("#btn-add-more-person").hasClass("step-hidden")) {
    $("#btn-add-more-person").removeClass("step-hidden");
  }
});

function loadReceiverForm(divId, index) {
  var div = document.createElement("div");
  div.classList.add("each");
  div.id = divId;
  div.style.position = "relative";
  $("#add-person-info").append(div);
  let receiver = receiverInfo(index);
  $(`#${divId}`).append(`<hr id="hr-${index}" style="margin-bottom: 70px;"/>`);
  $(`#${divId}`).append(receiver);
}

function addMorePerson(divId, index) {
  $("#add-person-info").children("#div-btn-add").remove();
  loadReceiverForm(divId, index);
  var divBtn = document.createElement("div");
  divBtn.classList.add("d-flex", "mb-5", "align-items-center", "mt-5");
  divBtn.id = "div-btn-add";
  $("#add-person-info").append(divBtn);
  let records = document.getElementById("add-person-info").childElementCount - 1;
  document.getElementById("div-btn-add").insertAdjacentHTML(
            "afterbegin",
            `<p class="mb-0 mr-4">Total receivers: <span>${records}</span></p>`
          );
  document.getElementById("div-btn-add").appendChild(btnAddMorePerson)
}

//parcel
function parcelDetail(index, count) {
  return `<div class="row" id="details-${index}-${count}">
                <div class="col-sm-7">
                    <div class="input-group">
                        <span
                            class="postoffice-form-control-wrap"><input
                                type="text"
                                name="name-${index}-${count}"
                                class="postoffice-form-control postoffice-text"
                                aria-invalid="false"
                                placeholder="Name">
                        </span>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span
                            class="postoffice-form-control-wrap"><input
                                type="text"
                                name="qty-${index}-${count}"
                                class="postoffice-form-control postoffice-text"
                                aria-invalid="false"
                                placeholder="Qty">
                        </span>
                    </div>
                </div>
                <div class="col-sm-3 d-flex" style="padding-top: 10px;">
                    
                </div>
            </div>`;
}

//btn-add-more-parcel-1
$("#btn-add-more-parcel-1").on("click", () => {
  loadParcelDetail(1);
});

//btn-add-more-parcel-
function addMoreParcel(index) {
  loadParcelDetail(index);
}

function loadParcelDetail(index) {
  let num = $(`#parcel-detail-${index}`).children(".row").length + 1;
  $(`#parcel-detail-${index}`).append(parcelDetail(index, num));

  let btnRemoveParcel = document.createElement("button");
  btnRemoveParcel.classList.add(
    "align-items-center",
    "btn",
    "btn-danger",
    "d-flex",
    "justify-content-center",
    "p-0"
  );
  btnRemoveParcel.id = `btn-rm-parcel-${index}-${num}`;
  btnRemoveParcel.style.borderRadius = "50%";
  btnRemoveParcel.style.height = "30px";
  btnRemoveParcel.style.width = "30px";
  let btnRemoveParcelIcon = document.createElement("i");
  btnRemoveParcelIcon.classList.add("fa-solid", "fa-trash-can");
  btnRemoveParcelIcon.style.fontSize = "15px";
  btnRemoveParcel.append(btnRemoveParcelIcon);
  $(`#details-${index}-${num}`).children(".col-sm-3").append(btnRemoveParcel);
  btnRemoveParcel.addEventListener("click", () => {
    $(`#parcel-detail-${index}`).children(`#details-${index}-${num}`).remove();
  });
}

//=======================receiver======================

//AJAX
//service
function getServiceList(serviceId) {
  $.ajax({
    url: `Service/GetServiceList?serviceId=` + serviceId,
    type: "get",
    dataType: "json",
    contentType: "application/json",
    success: function (response) {
      let count = 1;
      $("#service-list").children("ul").find("div").empty();
      response.forEach((item) => {
        let li = `<li style="padding: 0 20px;font-size: 14px;" id="selected-service-${count}" data-id="${item.id}">
                            <a role="button">${item.name}</a>
                        </li>`;
        $("#service-list").children("ul").find("div").append(li)
        $(`#selected-service-${count}`).on("click", () => {
          $("#service-list").find("button").text(item.name)
          $("#service-list").find("button").attr('data-id', item.id)
          $("#service-list").find("button").attr('data-name', item.name)
        });
        count++;
      });
    },
    error: function (data) {
      alert(data.responseText.message);
    },
  });
}
getServiceList(0);

//product
//product cate
let pCateId = 0;
function getProductCateList(parentId) {
  $.ajax({
    url: `Product/GetProductCategoryByParent?parentId=` + parentId,
    type: "get",
    dataType: "json",
    contentType: "application/json",
    success: function (response) {
      $(`#product-cate-list-${_modalIndex}`).children("ul").find("div").empty()
      $(`#product-cate-list-${_modalIndex}`).children("ul").find("div")
        .append(`<li style="padding: 0 20px;font-size: 13px;" id="product-cate-0-${_modalIndex}" data-name="All">
                                                                            <a role="button" onClick="getProductByPCate(0)">All</a>
                                                                        </li>`)
      response.forEach((item) => {
        let li = `<li style="padding: 0 20px;font-size: 13px;" id="product-cate-${item.id}-${_modalIndex}" data-name="${item.name}">
                            <a role="button" onClick="getProductByPCate(${item.id})">${item.name}</a>
                        </li>`
        $(`#product-cate-list-${_modalIndex}`).children("ul").find("div").append(li)
      });
    },
    error: function (data) {
      alert(data.responseText.message)
    },
  });
}
getProductCateList(0)
function getProductByPCate(pCateId) {
  $(`#product-cate-list-${_modalIndex}`).find("button").text($(`#product-cate-${pCateId}-${_modalIndex}`).attr('data-name'));
  $.ajax({
    url: "Product/GetProductsByPCate?categoryId=" + pCateId,
    type: "get",
    dataType: "json",
    contentType: "application/json",
    success: function (response) {
      $(`#div-product-${_modalIndex}`).empty();
      response.forEach((item) => {
        let li = `<li id="li-product-${item.id}-${_modalIndex}" class="col-sm-12 mb-3" data-photo="../../img/ProductThumbnail/${item.thumbnail}" data-name="${item.name}" data-code="${item.code}" 
                      data-price="${item.price}" data-qty="1" data-color="${item.color}" data-productId="${item.id}" data-attributeId="" 
                      data-length="${item.length}" data-width="${item.width}" data-height="${item.height}">
                    <div class="align-items-center row"
                        style="line-height: 30px;">
                        <div class="col-1 d-flex justify-content-center">
                            <img src="../../img/ProductThumbnail/${item.thumbnail}"
                                alt="" width="30" height="30">
                        </div>
                        <div class="align-items-center col-11 d-flex justify-content-between text-center">
                            <div style="line-height: 17px;flex: 2;" class="text-left">
                                <p class="m-0" id="attr-name-${item.id}-${_modalIndex}">${item.name}</p>
                                <p class="m-0" id="attr-code-${item.id}-${_modalIndex}" style="font-size: 10px;">#${item.code}</p>
                            </div>
                            <div class="input-group" style="margin-bottom: 0 !important;width: 30%; flex:2;" id="div-attribute-${item.id}">
                                
                            </div>
                            <p class="m-0" style="flex:1;" id="attr-qty-${item.id}-${_modalIndex}" data-qty="${item.qty}">${item.qty} item(s) left</p>
                            <p class="m-0" style="flex:1;" id="attr-price-${item.id}-${_modalIndex}" data-price="${item.price}">${item.price == null ? 0 : item.price.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'})}</p>
                            <div style="flex: 1;height: 30px;padding: 0 12px;" class="d-flex" id="modify-qty-${item.id}-${_modalIndex}">
                                <button class="btn btn-sm btn-outline-danger" onClick="substractQty(${item.id})" type="button"><i class="fa-solid fa-minus"></i></button>
                                <input type="text" value="1" style="padding: 0 5px;" class="text-center" onkeyup="modifyQty(${item.id})"/>
                                <button class="btn btn-sm btn-outline-dark" onClick="addQty(${item.id})" type="button"><i class="fa-solid fa-plus"></i></button>
                            </div>
                            <button class="btn" id="btn-add-to-cart-${item.id}-${_modalIndex}" style="background-color: #ffdc39;height: 30px;font-size: 12px;" type="button"
                                    onClick="addToCart(${item.id})">
                                <i class="fa-solid fa-basket-shopping"></i>
                            </button>
                        </div>
                    </div>
                  </li>`;
        $(`#div-product-${_modalIndex}`).append(li);
        getProductAttributeByProduct(item.id);
      });
    },
    error: function (data) {
      alert(data.responseText.message);
    },
  });
}
getProductByPCate(0)

function getProductAttributeByProduct(productId) {
    $.ajax({
        url: 'Product/GetProductAttributeByProduct?productId='+productId,
        type: 'get',
        dataType: 'json',
        contentType: 'application/json',
        success: function(response){
           let div = `<div style="border: 1px solid rgba(119, 119, 119, 0.2);">
                        <div class="dropdown" id="product-attribute-list-${productId}-${_modalIndex}" style="height: 40px;">
                            <a class="btn dropdown-toggle p-0 tg-pattribute"
                                href="#" role="button"
                                id="select-product-attribute-${productId}-${_modalIndex}"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                                style="height: 100%; width: 100%; overflow: hidden;">
                                <button style="background-color: transparent;color: #111;width: 100%;text-align: left;font-size: 11px;padding: 12px 10px;"
                                    class="btn-sm d-flex">Select product attribute</button>
                            </a>
                            <ul class="dropdown-menu p-0 ul-dropdown"
                                aria-labelledby="select-product-attribute-${productId}-${_modalIndex}"
                                style="height: 142px; width: 100%; border-radius: 0px; line-height: 40px; overflow: hidden">
                                <li style="padding: 0 10px;font-size: 12px;">
                                    --Select product attribute</li>
                                    <div style="overflow: hidden scroll;height: 105px;font-size: 13px;padding: 0 0 0 12px;margin-top: -4px;" 
                                        id="div-product-attribute-${productId}-${_modalIndex}"> 
                                        
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>`
            if(response.length != 0) {
              $(`#div-attribute-${productId}`).append(div)
              let defaultAttribute = (response[0].lengthValue != null ? "L:"+response[0].lengthValue : "")
                                   + (response[0].widthValue != null ? "W:"+response[0].widthValue : "")
                                   + (response[0].heightValue != null ? "H:"+response[0].heightValue : "")
              let text = `<div style="height: 15px;width: 15px;${response[0].colorValue != null ? "background-color: "+response[0].colorValue+";" : ""}" class="mr-2 ${response[0].colorValue != null ? "d-block":"d-none"}"></div>
                          <p class="mb-0">${defaultAttribute}</p>`
              $(`#select-product-attribute-${productId}-${_modalIndex}`).children('button').empty()
              $(`#select-product-attribute-${productId}-${_modalIndex}`).children('button').append(text)
              $(`#attr-qty-${productId}-${_modalIndex}`).text(response[0].qty+" item(s) left")
              $(`#attr-price-${productId}-${_modalIndex}`).text(response[0].price.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
              $(`#attr-qty-${productId}-${_modalIndex}`).attr('data-qty', response[0].qty)
              $(`#attr-price-${productId}-${_modalIndex}`).attr('data-price', response[0].price)

              //updateProductLiBySelectAttribute
              $(`#li-product-${productId}-${_modalIndex}`).attr('data-color', response[0].colorValue)
              $(`#li-product-${productId}-${_modalIndex}`).attr('data-length', response[0].lengthValue)
              $(`#li-product-${productId}-${_modalIndex}`).attr('data-width', response[0].widthValue)
              $(`#li-product-${productId}-${_modalIndex}`).attr('data-height', response[0].heightValue)
              $(`#li-product-${productId}-${_modalIndex}`).attr('data-price', response[0].price)
              $(`#li-product-${productId}-${_modalIndex}`).attr('data-attributeId', response[0].id)
            }
            $(`#div-product-attribute-${productId}`).empty()
            response.forEach(item=>{
              //change qty+price by attr
                let li = `<li id="li-attribute-${item.id}-${_modalIndex}">
                            <a class="p-0 align-items-center d-flex mb-2" style="height: 30px;" 
                              data-id="${item.id}" data-color="${item.colorValue}" data-length="${item.lengthValue}" 
                              data-width="${item.widthValue}" data-height="${item.heightValue}" data-qty="${item.qty}" data-price="${item.price}"
                              onClick="selectAttribute(${item.id}, ${item.productId})">
                                <p class="${item.colorValue == null ? "d-none" : "d-block"} mr-2 mb-0" 
                                style="background-color: ${item.colorValue};width: 20px;height: 20px;"></p>
                                <p class="mb-0">
                                    ${item.lengthValue != null ? "L:"+item.lengthValue : ""}
                                    ${item.widthValue != null ? "W:"+item.widthValue : ""}
                                    ${item.heightValue != null ? "H:"+item.heightValue : ""}
                                </p>
                            </a>
                          </li>`
                $(`#div-product-attribute-${productId}-${_modalIndex}`).append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
  })
}

function selectAttribute(attributeId, productId){
  let item = $(`#li-attribute-${attributeId}-${_modalIndex}`).children('a')
  let id = item.attr('data-id') != "null" ? item.data('data-id') : ""
  let color = item.attr('data-color')
  let length = item.attr('data-length')
  let width = item.attr('data-width')
  let height = item.attr('data-height')
  let qty = item.attr('data-qty') != "null" ? item.attr('data-qty') : ""
  let price = item.attr('data-price') != "null" ? item.attr('data-price') : ""

  let attribute = (length != "null" ? "L:"+length :'')+(width != "null" ? "W:"+width : "")+(height != "null" ? "H:"+height : "")
  let text = `<div style="height: 15px;width: 15px;${color != "null" ? "background-color: "+color+";" : ""}" 
                  class="mr-2 ${color != "null" ? "d-block" : "d-none"}"></div>
              <p class="mb-0">${attribute}</p>`
  $(`#select-product-attribute-${productId}-${_modalIndex}`).children('button').empty()
  $(`#select-product-attribute-${productId}-${_modalIndex}`).children('button').append(text)
  $(`#attr-qty-${productId}-${_modalIndex}`).text(qty+" item(s) left")
  $(`#attr-price-${productId}-${_modalIndex}`).text(parseFloat(price).toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#attr-qty-${productId}-${_modalIndex}`).attr('data-qty', qty)
  $(`#attr-price-${productId}-${_modalIndex}`).attr('data-price', price)
  $(`#modify-qty-${productId}-${_modalIndex}`).children('input').val(1)

  //updateProductLiBySelectAttribute
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-color', color)
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-length', length)
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-width', width)
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-height', height)
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-price', price)
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-attributeId', attributeId)
}

//change qty
function substractQty(productId){
  let qty = $(`#modify-qty-${productId}-${_modalIndex}`).children('input')
  if(qty.val().trim() == "") qty.val(1)
  if(parseInt(qty.val()) > 1){
    qty.val(parseInt(qty.val()) - 1)
  } else {
    $(`#li-product-${productId}-${_modalIndex}`).attr('data-qty', qty.val())
    return
  }
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-qty', qty.val())
}

function addQty(productId){
  let qty = $(`#modify-qty-${productId}-${_modalIndex}`).children('input')
  let stock = $(`#attr-qty-${productId}-${_modalIndex}`).attr('data-qty')
  if(qty.val().trim() == "") qty.val(0)
  if(parseInt(qty.val()) < stock){
    qty.val(parseInt(qty.val()) + 1)
  } else {
    $(`#li-product-${productId}-${_modalIndex}`).attr('data-qty', qty.val())
    toastAlert('Product quantity', `Quantity must not exceed ${stock}`, info, 3000)
    return
  }
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-qty', qty.val())
}

let regexQty = new RegExp("^[0-9]*$")
function modifyQty(productId){
  let input = $(`#modify-qty-${productId}-${_modalIndex}`).children('input')
  let stock = $(`#attr-qty-${productId}-${_modalIndex}`).attr('data-qty')
  if(regexQty.test(input.val())){
    if(parseInt(input.val()) > parseInt(stock)) {
      input.val(stock)
      toastAlert('Product quantity', `Quantity must not exceed ${stock}`, info, 3000)
    }
    if(parseInt(input.val()) < 1) input.val(1)
  } else input.val(1)
  $(`#li-product-${productId}-${_modalIndex}`).attr('data-qty', input.val())
}

//add to cart
let totalcart = 0
totalCart()
function addToCart(productId){
  let addedQty = checkIfProductExists(productId)
  let stock = $(`#attr-qty-${productId}-${_modalIndex}`).attr('data-qty')
  let photo = $(`#li-product-${productId}-${_modalIndex}`).attr('data-photo')
  let name = $(`#li-product-${productId}-${_modalIndex}`).attr('data-name')
  let code = $(`#li-product-${productId}-${_modalIndex}`).attr('data-code')
  let qty = $(`#li-product-${productId}-${_modalIndex}`).attr('data-qty')
  if((addedQty + parseInt(qty)) > stock){
    return toastAlert('Product quantity', `You have reached the maximum quantity of this product ${stock}/${stock}`, info, 3000)
  }
  let price = $(`#li-product-${productId}-${_modalIndex}`).attr('data-price')
  let attribute = $(`#li-product-${productId}-${_modalIndex}`).attr('data-attributeId')
  let color = $(`#li-product-${productId}-${_modalIndex}`).attr('data-color')
  let length = $(`#li-product-${productId}-${_modalIndex}`).attr('data-length')
  let width = $(`#li-product-${productId}-${_modalIndex}`).attr('data-width')
  let height = $(`#li-product-${productId}-${_modalIndex}`).attr('data-height')
  let productAttribute = productId+(attribute != '' ? "-"+attribute : '-0')
  let subtotal = parseFloat(price)*parseInt(qty)

  let rows = parseInt($(`#tbody-product-${_modalIndex}`).attr('data-rows'))
  if(rows == 0) $(`#tbody-product-${_modalIndex}`).children(`#tbody-default-${_modalIndex}`).remove()

  let tr = `<tr class="postalservice-cart-form__cart-item cart_item" data-product="${productId}" data-photo="${photo}" data-code="${code}"
                data-name="${name}" data-qty="${qty}" data-price="${price}" data-subtotal="${subtotal}"
                data-attribute=""  data-color="${color}" data-length="${length}"
                data-width="${width}" data-height="${height}" id="tr-product-${productAttribute}-${_modalIndex}">
              <td class="product-remove">
                <button id="btn-remove-product-${productAttribute}-${_modalIndex}" 
                        onClick="removeProduct(${productId}, ${attribute == '' ? 0 : parseInt(attribute)})" type="button" style="border-radius: 50%;background-color: transparent;color: #dc3545;padding: 0 10px;">
                 <i class="fa-solid fa-trash-can"></i>
                </button>
              </td>
              <td class="product-thumbnail">
                <a href="#">
                  <img width="40" height="40" src="${photo}"
                    class="attachment-postalservice_thumbnail size-postalservice_thumbnail">
                </a>
              </td>
              <td class="product-name">
                <a href="#">${name}</a>
                <p class="mb-0">#${code}</p>
              </td>
              <td class="product-type d-flex align-items-center" style="line-height: 3.5rem; height: 4.5rem;">
                <div style="height: 15px;width: 15px;${(color != undefined && color != 'null' && attribute != '')? "background-color: "+color+";" : ""}" 
                  class="mr-2 ${(color != undefined && color != 'null' && attribute != '')? "d-block" : "d-none"}"></div>
                <p class="mb-0">${(length != undefined && length != 'null' && attribute != '') ? "L:"+length : ""} ${(width != undefined && width != 'null' && attribute != '') ? "W:"+width : ""} ${(height != undefined && height != 'null' && attribute != '') ? "H:"+height : ""}</p>
              </td>
              <td class="product-price">
                <span class="postalservice-Price-amount amount">
                  ${parseFloat(price).toLocaleString('vi-VN', {style : 'currency', currency : 'VND'})}
                </span>
              </td>
              <td class="product-quantity">
                <div class="quantity">
                  <input type="number" class="input-text qty text" step="1" min="0" max="" name="" onchange="changeCartQty(${productId}, ${attribute == '' ? 0 : parseInt(attribute)})"
                    oninput="changeCartQty(${productId}, ${attribute == '' ? 0 : parseInt(attribute)})" value="${qty}" inputmode="numeric" 
                    id="cart-qty-${productAttribute}-${_modalIndex}">
                </div>
              </td>
              <td class="product-subtotal">
                <span class="postalservice-Price-amount amount">
                ${subtotal.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'})}
                </span>
              </td>
            </tr>`
  let trProduct = `tr-product-${productAttribute}-${_modalIndex}`
  let cartQty = `cart-qty-${productAttribute}-${_modalIndex}`
  if($(`#tbody-product-${_modalIndex}`).find(`#${trProduct}`).length && $(`#tbody-product-${_modalIndex}`).find(`#${trProduct}`).attr('data-attribute') == '' || 
     $(`#tbody-product-${_modalIndex}`).find(`#${trProduct}`).length && $(`#tbody-product-${_modalIndex}`).find(`#${trProduct}`).attr('data-attribute') == attribute){
    let cummulativeQty = parseInt($(`#${cartQty}`).val())
    let urlchangeCartQty = attribute == '' ? ('Product/GetProduct?productId='+productId) : ('Product/GetProductAttribute?attributeId='+parseInt(attribute))
    $.ajax({
      url: urlchangeCartQty,
      type: 'get',
      dataType: 'json',
      async: false,
      contentType: 'application/json',
      success: function(response){
        if((cummulativeQty + parseInt(qty)) > response.qty){
            toastAlert('Product quantity', `Quantity must not exceed ${response.qty}`, info, 3000)
            cummulativeQty = response.qty - cummulativeQty
            $(`#${cartQty}`).attr('value', response.qty)
            $(`#${cartQty}`).val(response.qty )
            $(`#${trProduct}`).attr('data-qty', response.qty)
            $(`#${trProduct}`).attr('data-subtotal', response.qty*price)
            $(`#${trProduct}`).find('.product-subtotal span').text((response.qty *price).toLocaleString('vi-VN', {style: 'currency', currency: 'VND'}))
            totalcart += (parseFloat(price)*parseInt(cummulativeQty))
            updateTotal(productAttribute, response.qty)
        } else {
          cummulativeQty += parseInt(qty)
          $(`#${cartQty}`).attr('value', cummulativeQty)
          $(`#${cartQty}`).val(cummulativeQty)
          $(`#${trProduct}`).attr('data-qty', cummulativeQty)
          $(`#${trProduct}`).attr('data-subtotal', cummulativeQty*price)
          $(`#${trProduct}`).find('.product-subtotal span').text((cummulativeQty*price).toLocaleString('vi-VN', {style: 'currency', currency: 'VND'}))
          totalcart += (parseFloat(price)*parseInt(qty))
          updateTotal(productAttribute, cummulativeQty)
        }
      },
      error: function(data){
        alert(data.responseText.message)
      }
    })
  } else {
    $(`#tbody-product-${_modalIndex}`).append(tr)
    $(`#tbody-product-${_modalIndex}`).attr('data-rows', (rows + 1))
    $(`#${trProduct}`).attr('data-attribute', attribute)
    $(`#${cartQty}`).attr('data-qty', qty)
    $(`#${cartQty}`).val(qty)
    $(`#${trProduct}`).attr('data-qty', qty)
    let addQty = checkIfProductExists(productId)
    console.log("cartadded:"+addQty)
    totalcart += (parseFloat(price)*parseInt(qty))
    totalCart()
  }
}

let emptyCart = `<tr id="tbody-default-${_modalIndex}"><td colspan="7" class="text-center">Empty cart</td></tr>`
if(document.getElementById(`tbody-product-${_modalIndex}`).childElementCount == 0) {
  $(`#tbody-product-${_modalIndex}`).append(emptyCart)
  $(`#tbody-product-${_modalIndex}`).attr('data-rows', 0)
  totalcart = 0
  totalCart()
}
//removeProduct
function removeProduct(productId, attributeId){
  let productAttribute = productId+(attributeId != '' ? "-"+attributeId : '-0')
  let trProduct = `tr-product-${productAttribute}-${_modalIndex}`
  let subtractPrice = $(`#tbody-product-${_modalIndex}`).children(`#${trProduct}`).attr('data-subtotal')
  $(`#tbody-product-${_modalIndex}`).children(`#${trProduct}`).remove()
  let rowCount = document.getElementById(`tbody-product-${_modalIndex}`).childElementCount ?? 0
  if(rowCount == 0) {
    $(`#tbody-product-${_modalIndex}`).append(emptyCart)
    $(`#tbody-product-${_modalIndex}`).attr('data-rows', rowCount)
    totalcart = 0
    totalCart()
    return
  }
  $(`#tbody-product-${_modalIndex}`).attr('data-rows', document.getElementById(`tbody-product-${_modalIndex}`).childElementCount)
  totalcart -= subtractPrice
  totalCart()
}

//change qty in cart
function changeCartQty(productId, attributeId){
  let cartQty = productId+(attributeId != '' ? "-"+attributeId : '-0')
  let qty = $(`#cart-qty-${cartQty}-${_modalIndex}`)
  let addedQty = checkIfProductExists(productId)
  console.log("added:"+addedQty)
  let stock = $(`#attr-qty-${productId}-${_modalIndex}`).attr('data-qty')

  let oldQty = qty.attr('data-qty')
  qty.attr('data-qty', qty.val())
  $(`#tr-product-${cartQty}-${_modalIndex}`).attr('data-qty', qty.val())
  
  if(regexQty.test(qty.val())){
    console.log("here:"+addedQty)
    if(parseInt(qty.val()) < 1) {
      qty.attr('data-qty', 1)
      $(`#tr-product-${cartQty}-${_modalIndex}`).attr('data-qty', 1)
      qty.val(1)
      console.log("<1:"+qty.attr('data-qty'))
    }
    if(parseInt(qty.val()) == 1){
      updateTotal(cartQty, 1)
    }
    if(parseInt(qty.val()) > 1){
      if(parseInt(qty.val()) > parseInt(stock)){
          toastAlert('Product quantity', `Quantity must not exceed ${parseInt(stock)}`, info, 3000)
          qty.attr('data-qty', parseInt(stock))
          qty.val(parseInt(stock))
          updateTotal(cartQty, parseInt(stock))
      } else {
        if((addedQty + (Math.abs(parseInt(qty.val())) - addedQty)) > parseInt(stock)){
          console.log(">1-add:"+addedQty+"qty:"+qty.attr('data-qty'))
          qty.attr('data-qty', oldQty)
          $(`#tr-product-${cartQty}-${_modalIndex}`).attr('data-qty', oldQty)
          qty.val(oldQty)
          return toastAlert('Product quantity', `You have reached the maximum quantity of this product ${stock}/${stock}`, info, 3000)
        }
        updateTotal(cartQty, parseInt(qty.attr('data-qty')))
      }
    }
  }
}

//cart total
function updateTotal(id, qty){
  let subtractSubtotal = $(`#tr-product-${id}-${_modalIndex}`).attr('data-subtotal')
  let subtotal = parseFloat($(`#tr-product-${id}-${_modalIndex}`).attr('data-price'))*parseInt(qty)
  $(`#cart-qty-${id}-${_modalIndex}`).attr('data-qty', qty)
  $(`#tr-product-${id}-${_modalIndex}`).attr('data-qty', qty)
  $(`#tr-product-${id}-${_modalIndex}`).children('.product-subtotal').find('span').text(subtotal.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#tbody-product-${_modalIndex}`).children(`#tr-product-${id}-${_modalIndex}`).attr('data-subtotal', subtotal)
  totalcart = totalcart - subtractSubtotal + subtotal
  totalCart()
}
function totalCart(){
  $(`#tbody-total-cart-${_modalIndex}`).children('.cart-subtotal').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#tbody-total-cart-${_modalIndex}`).children('.cart-subtotal').attr('data-subtotal-product', totalcart)
  $(`#tbody-total-cart-${_modalIndex}`).children('.order-total').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#tbody-total-cart-${_modalIndex}`).children('.order-total').attr('data-total-product', totalcart)
  if($(`#tbody-product-${_modalIndex}`).attr('data-rows') != "0"){
    $(`#btn-receiver-add-product-${_modalIndex}`).children('span').text($(`#tbody-product-${_modalIndex}`).attr('data-rows')+" item(s)")
  }
}

//toast
const error = 0
const success = 1
const info = 2
const warning = 3
function toastAlert(title, message, status, hide){
  let icon
  switch(status){
    case success:
      icon = 'success'
      break
    case error:
      icon = 'error'
      break
    case info:
      icon = 'info'
      break
    case warning:
      icon = 'warning'
      break
  }
  $.toast({
    heading : title,
    text : message,
    position : {left:600,top:100},
    stack: false,
    allowToastClose: true,
    showHideTransition: 'fade',
    hideAfter: hide,
    icon : icon
  })
}

window.addEventListener("click", function (e) {
  if (document.getElementById(`product-cate-list-${_modalIndex}`).contains(e.target)) {
    $(`#product-cate-list-${_modalIndex}`).children("ul").css("display", "block");
  } else {
    $(`#product-cate-list-${_modalIndex}`).children("ul").css("display", "none");
  }
  if (document.getElementById(`product-list-${_modalIndex}`).contains(e.target)) {
    $(`#product-list-${_modalIndex}`).children("ul").css("display", "block");
  } else {
    $(`#product-list-${_modalIndex}`).children("ul").css("display", "none");
  }
});

//step5
//service
function reviewService(){
  $('#payment-service').find('p:first-child span').text($('#select-service').find('button').attr('data-name'))
  $('#payment-service').find('p:last-child span span').text($('input[name="sending-date"]').val())
  let totalReceivers = $('#single-person').is(':checked') ? $('#add-person-info').children().length : ($('#add-person-info').children().length - 1)
  $('#total-receivers').text(totalReceivers)
}
//sender
function reviewSender(){
  $('#payment-sender').children('p:nth-child(1)').find('span').text($('input[name="sender-first-name"]').val()+" "+$('input[name="sender-last-name"]').val())
  $('#payment-sender').children('p:nth-child(2)').find('span').text($('input[name="from-phone"]').val())
  $('#payment-sender').children('p:nth-child(3)').find('span').text($('input[name="from-email"]').val())
  let senderAddress = $('input[name="from-address"]').val()+", "
                    +$('#select-sender-ward').children('button').attr('data-ward-value')+", "
                    +$('#select-sender-district').children('button').attr('data-district-value')+", "
                    +$('#select-sender-province').children('button').attr('data-province-value')
  $('#payment-sender').children('p:nth-child(4)').find('span').text(senderAddress)
}
//receiver
let _totalBill = 0
function reviewReceiver(){
  _totalBill = 0
  $('#payment-receiver').empty()
  let arr = getListReceiverIndexes()
  let shippingFee = 0
  for(let i = 0; i < arr.length; i++){
    let address = $(`input[name="to-address-${arr[i]}"]`).val()+", "+
                  $(`#select-receiver-ward-${arr[i]}`).children('button').attr('data-ward-value')+", "+
                  $(`#select-receiver-district-${arr[i]}`).children('button').attr('data-district-value')+", "+
                  $(`#select-receiver-province-${arr[i]}`).children('button').attr('data-province-value')
    let figures = "W:"+$(`input[name="weight-${arr[i]}"]`).val()+"kg, L:"+$(`input[name="length-${arr[i]}"]`).val()+"cm, W:"+
                  $(`input[name="width-${arr[i]}"]`).val()+"cm, H:"+$(`input[name="height-${arr[i]}"]`).val()+"cm"
    let trReceiver = `<tr>
                        <th scope="row">${i+1}</th>
                        <td>${$(`input[name="receiver-first-name-${arr[i]}"]`).val()+" "+$(`input[name="receiver-last-name-${arr[i]}"]`).val()}</td>
                        <td>${$(`input[name="to-phone-${arr[i]}"]`).val()}</td>
                        <td>${$(`input[name="to-email-${arr[i]}"]`).val()}</td>
                        <td>${address}</td>
                        <td>${$(`input[name="pin-code-${arr[i]}"]`).val()}</td>
                        <td>${figures}</td>
                        <td>${parseFloat(14000).toLocaleString('vi-VN', {style:'currency', currency:'VND'})}</td>
                        <td>${parseFloat($(`input[name="amount-${arr[i]}"]`).val()).toLocaleString('vi-VN', {style:'currency', currency:'VND'})}</td>
                        <td>${$(`textarea[name="notes-${arr[i]}"]`).val()}</td>
                      </tr>`
    shippingFee += parseFloat(14000) 
    $('#payment-receiver').append(trReceiver)
  }
  $('#payment-pickup-fee').text(parseFloat(30000).toLocaleString('vi-VN', {style:'currency', currency:'VND'}))
  $('#payment-shipping-fee').text(parseFloat(shippingFee).toLocaleString('vi-VN', {style:'currency', currency:'VND'}))
  _totalBill = parseFloat(30000) + shippingFee
}
//product
function reviewProduct(){
  $('#payment-product').empty()
  let arr = $(`#tbody-product-${_modalIndex}`).children().toArray()
  for(let i = 0; i < arr.length; i++){
    let id = arr[i].id
    let attribute = $(`#${id}`).attr('data-attribute')
    let color = $(`#${id}`).attr('data-color') 
    let length = $(`#${id}`).attr('data-length')
    let width = $(`#${id}`).attr('data-width') 
    let height = $(`#${id}`).attr('data-height') 
    let trProduct = `<tr>
                      <th scope="row">${i+1}</th>
                      <td>
                        <div class="align-items-center d-flex">
                          <img src="${$(`#${id}`).attr('data-photo')}" width="50" class="mr-2">
                          <div>
                            <p class="mb-0">${$(`#${id}`).attr('data-name')}</p>
                            <p class="mb-0">${$(`#${id}`).attr('data-code')}</p>
                          </div>
                        </div>
                      </td>
                      <td>
                        <div class="align-items-center d-flex">
                          <div class="${color != 'undefined' && color != 'null' && attribute != '' ? 'd-block' : 'd-none'} mr-2" 
                                style="${color != 'undefined' && color != 'null' && attribute != '' ? 'background-color:'+color+';' : ''}height: 15px;width: 15px;"></div>
                          <p class=mb-0>${(length != 'undefined' && length != 'null' && attribute != '') ? "L:"+length : ""} ${(width != 'undefined' && width != 'null' && attribute != '') ? "W:"+width : ""} ${(height != 'undefined' && height != 'null' && attribute != '') ? "H:"+height : ""}</p>
                        </div>
                      </td>
                      <td>${parseFloat($(`#${id}`).attr('data-price')).toLocaleString('vi-VN', {style:'currency', currency:'VND'})}</td>
                      <td>${$(`#${id}`).attr('data-qty')}</td>
                      <td>${parseFloat($(`#${id}`).attr('data-subtotal')).toLocaleString('vi-VN', {style:'currency', currency:'VND'})}</td>
                    </tr>` 
    $('#payment-product').append(trProduct)
  }
  $('#payment-total-product').text(parseFloat($('.order-total').attr('data-total-product')).toLocaleString('vi-VN', {style:'currency', currency:'VND'}))
  $('#payment-total').text(parseFloat(_totalBill+parseFloat($('.order-total').attr('data-total-product'))).toLocaleString('vi-VN', {style:'currency', currency:'VND'}))
}

//##################################################################CREATE
let userData = localStorage.getItem('user_data')
if (!userData) {
  let div = `<div class="container" style="height: 300px;">
              <h1 class="mb-4">Sign in to schedule an order</h1>
              <div class="d-flex">
                  <a class="btn mr-3" href="/Authentication/SignIn" style="background-color: #ffdc39;padding: 10px 20px;">Sign in</a>
                  <a class="btn" href="/Authentication/SignUp" style="background-color: #d9534f;padding: 10px 20px;color: #fff;">Sign up</a>
              </div>
            </div>` 
  $('.postoffice-form').children('.entry-content').empty()
  $('.postoffice-form').children('.entry-content').append(div)
}
userData = JSON.parse(userData)

let now = new Date().toLocaleString().replace(',','')
const proccessing = 2
const pending = 0
const unpaid = 0
const paid = 1
const momo = 2
const onepay = 1
const cod = 0
const firstTrackingDescription = 'Your request is pending'
let randomCode = new Date().getTime().toString()
$('#cod').prop('checked', true)

function productList(arr){
  let list = new Array()
  for(let i = 0; i < arr.length; i++)
  {
    let color = arr[i].getAttribute('data-color')
    let length = arr[i].getAttribute('data-length')
    let width = arr[i].getAttribute('data-width')
    let height = arr[i].getAttribute('data-height')
    let item = {"ProductId": parseInt(arr[i].getAttribute('data-product')), 
                "ProductAttributeId" : arr[i].getAttribute('data-attribute') == '' ? 0 : parseInt(arr[i].getAttribute('data-attribute')),
                "Name" : `${arr[i].getAttribute('data-name')}`,
                "Code" : `${arr[i].getAttribute('data-code')}`,
                "Color" : `${color == "undefined" || color == 'null' ? '' : color}`,
                "Length" : `${length == "undefined" || length == 'null' ? '' : length}`,
                "Width" : `${width == "undefined" || width == 'null' ? '' : width}`,
                "Height" : `${height == "undefined" || height == 'null' ? '' : height}`,
                "Price" : parseInt(arr[i].getAttribute('data-price')),
                "Qty" : parseInt(arr[i].getAttribute('data-qty')),
                "SubTotal" : parseInt(arr[i].getAttribute('data-subtotal')),
                "CreatedAt" : now,
                }
    list.push(item)
  }
  return list
}

function getListReceiverIndexes(){
  let arr = new Array()
  let addInfo = $('#add-person-info').children().toArray()
  for(let i = 0; i < addInfo.length; i++){
    if(addInfo[i].id != 'div-btn-add'){
      let item = parseInt(addInfo[i].id.replace('add-person-info-',''))
      arr.push(item)
    }
  }
  return arr
}

function getListOrderDetailIndexes(index){
  let arr = new Array()
  let addOrderDetail = $(`#parcel-detail-${index}`).children().toArray()
  for(let i = 0; i < addOrderDetail.length; i++){
    let item = addOrderDetail[i].id.replace(`details-`,'')
    arr.push(item)
  }
  return arr
}

let shippingFee = 0
function orderList(){
  let list = new Array()
  let arr = getListReceiverIndexes()
  for(let i = 0; i < arr.length; i++){
    let firstName = $(`input[name="receiver-first-name-${arr[i]}"]`).val()
    let lastName = $(`input[name="receiver-last-name-${arr[i]}"]`).val()
    let phone = $(`input[name="to-phone-${arr[i]}"]`).val()
    let email = $(`input[name="to-email-${arr[i]}"]`).val()
    let address = $(`input[name="to-address-${arr[i]}"]`).val()
    let province = parseInt($(`#select-receiver-province-${arr[i]}`).children('button').attr('data-province'))
    let district = parseInt($(`#select-receiver-district-${arr[i]}`).children('button').attr('data-district'))
    let ward = parseInt($(`#select-receiver-ward-${arr[i]}`).children('button').attr('data-ward'))
    let pinCode = $(`input[name="pin-code-${arr[i]}"]`).val()
    let length = $(`input[name="length-${arr[i]}"]`).val()
    let width = $(`input[name="width-${arr[i]}"]`).val()
    let height = $(`input[name="height-${arr[i]}"]`).val()
    let weight = $(`input[name="weight-${arr[i]}"]`).val()
    let note = $(`textarea[name="notes-${arr[i]}"]`).val()
    let collected = $(`input[name="amount-${arr[i]}"]`).val()
    let orderDetails = orderDetailList(arr[i])
    let orderPhotoNames = orderPhotoNameList(arr[i])
    let orderTracking = orderTrackingList(arr[i])
    let item = {"Code" : randomCode, "ReceiverFirstName" : firstName, 
                "ReceiverLastName" : lastName, "ReceiverPhone" : phone,
                "ReceiverEmail" : email, "ToAddress" : address, "ToWardId" : ward,
                "ToCityId" : district, "ToProvinceId" : province, "PinCode" : pinCode,
                "Length" : length, "Height" : height, "Width" : width, "Weight" : weight,
                "Notes" : note, "CollectedAmount" : collected, "CreatedAt" : now,
                "Status" : proccessing, "DeliveryStatus" : pending, "DeliveryFee" : 14000, 
                "OrderDetailList" : orderDetails, "OrderPhotoList" : orderPhotoNames, 
                "OrderTrackingList" : orderTracking
              }
    shippingFee += 14000
    list.push(item)
  }
  return list
}

function orderDetailList(index){
  let list = new Array()
  let arr = getListOrderDetailIndexes(index) 
  for(let i = 0; i < arr.length; i++){
    let name = $(`input[name="name-${arr[i]}"]`).val()
    let qty = $(`input[name="qty-${arr[i]}"]`).val()
    let item = {"Name" : name, "Qty" : qty}
    list.push(item)
  }
  return list
}

function orderPhotoNameList(index){
  let list = new Array()
  let photos = document.getElementById(`photos-${index}`).files
  if(photos.length == 0) return
  for(let i = 0; i < photos.length; i++){
    list.push(photos[i].name)
  }
  return list
}

function orderPhotoBlobList(){
  let arr = getListReceiverIndexes()
  let list = new Array()
  for(let i = 0; i < arr.length; i++){
    let photos = document.getElementById(`photos-${arr[i]}`).files
    if(photos.length == 0) return
    for(let k = 0; k < photos.length; k++){
      list.push(photos[k])
    }
  }
  return list
}

function orderTrackingList(index){
  let list = new Array()
  let tracking = {"Code" : randomCode, "Description" : firstTrackingDescription, 
                  "BranchId" : JSON.parse(getCookie('branch')).id, "CreatedAt" : now}
  list.push(tracking)
  return list
}

function send(){
  let paymentType = $('#onepay').is(':checked') ? onepay : 
                    ($('#momo').is(':checked') ? momo : cod)
  //productbill
  let customerId = userData.Id
  let totalProductBill = $(`#tbody-total-cart-${_modalIndex}`).children('.order-total').attr('data-total-product') != "0" ?
              parseFloat($(`#tbody-total-cart-${_modalIndex}`).children('.order-total').attr('data-total-product')) : 0
  let _productBill = totalProductBill == 0 ? null : {"CustomerId" : customerId, "Status" : proccessing, "Total" : totalProductBill, "CreatedAt" : now, "PaymentStatus" : (paymentType == cod ? unpaid : paid)}
  //productbilldetail
  let _productList = $(`#tbody-product-${_modalIndex}`).children().toArray().length == 0 ? null : productList($(`#tbody-product-${_modalIndex}`).children().toArray())
  //order  //orderdetail   //orderphoto  //ordertracking
  let _orderList = orderList()
  //bill
  let serviceId = $('#service-list').find('button').attr('data-id')
  let serviceName = $('#service-list').find('button').attr('data-name')
  let sendingDate = $('input[name="sending-date"]').val()
  let isPickedup = $('#pickup').is(':checked') ?? false
  let pickUpFee = parseFloat($('#pickup-fee').attr('data-pickup-fee'))
  let orderQty = $('#single-person').is(':checked') ? 1 :
                  document.getElementById("add-person-info").childElementCount - 1
  let totalBill = totalProductBill + pickUpFee + shippingFee
  let _bill = {"Code" : randomCode, "ServiceId" : serviceId, "ServiceName" : serviceName,
              "PickUpFee" : pickUpFee, "IsPickup" : isPickedup, "SendingOn" : sendingDate,
              "OrderQty" : orderQty, "Total" : totalBill, "PaymentType" : paymentType,
              "PaymentStatus" : (paymentType == cod ? unpaid : paid), "BranchId" : JSON.parse(getCookie('branch')).id, "CreatedAt" : now}

  var formData = new FormData()
  formData.append('name', $("input[name='img_name']").val())
  formData.append('categoryId', parseInt($("select[name='category']").val()))
  formData.append('status', parseInt($("select[name='img_status']").val()))
  formData.append('description', $("textarea[name='description']").val())

  var myAppUrlSettings =
  {
      MyUsefulUrl: 'http://localhost:4000/api/images/create?collectionId=' + collectionId
  }
  var request = new XMLHttpRequest();
  request.open('POST', myAppUrlSettings.MyUsefulUrl);
  request.setRequestHeader('Access-Control-Allow-Origin', '*')
  request.setRequestHeader('Authorization', 'Bearer ' + token)
  request.setRequestHeader('Accept', '*/*')        
  //request.setRequestHeader('Content-Type', 'application/json; charset=utf-8')        
  request.send(formData);
  request.onreadystatechange = function () {
  // Call a function when the state changes.
      if (this.readyState === XMLHttpRequest.DONE && this.status === 200)
      {
          var response = JSON.parse(request.responseText);
          if (response.message == "Successfully add image to collection")
          {
              $('#exampleModalToggle').modal('hide')
              window.location.reload()
          }
          if (response.message == "Fail to create add image to collection")
          {
              window.location.reload()
          }
      }
  }
}


//modal product receiver
function setModalIndex(modalIndex){
  _modalIndex = modalIndex
  totalcart = $(`#tbody-total-cart-${modalIndex}`).children('.order-total').attr('data-total-product') == "0" ? 0 : 
              parseFloat($(`#tbody-total-cart-${modalIndex}`).children('.order-total').attr('data-total-product'))
  if(totalcart == 0){
    $(`#tbody-total-cart-${_modalIndex}`).children('.cart-subtotal').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
    $(`#tbody-total-cart-${_modalIndex}`).children('.order-total').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  }
}

function clearReceiverProducts(modalIndex){
  _modalIndex = modalIndex
  if($(`#tbody-product-${modalIndex}`).children().toArray().length == 0) return
  $(`#tbody-product-${modalIndex}`).empty()
  $(`#tbody-product-${modalIndex}`).attr('data-rows', 0)
  totalcart = 0
  $(`#tbody-total-cart-${modalIndex}`).children('.cart-subtotal').attr('data-subtotal-product', totalcart)
  $(`#tbody-total-cart-${modalIndex}`).children('.order-total').attr('data-total-product', totalcart)
  $(`#tbody-total-cart-${_modalIndex}`).children('.cart-subtotal').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#tbody-total-cart-${_modalIndex}`).children('.order-total').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#btn-receiver-add-product-${modalIndex}`).children('span').text('')
}

//check if product exists and return its qty
function checkIfProductExists(productId){
  let _arr = getListReceiverIndexes()
  let qty = 0
  for (let i = 0; i < _arr.length; i++) {
    let arr = $(`#tbody-product-${_arr[i]}`).children().toArray()
    for(let k = 0; k < arr.length; k++){
      if(arr[k].getAttribute('data-product') == productId.toString()){
        qty += parseInt(arr[k].getAttribute('data-qty'))
      }
    }
  }
  return qty
}











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