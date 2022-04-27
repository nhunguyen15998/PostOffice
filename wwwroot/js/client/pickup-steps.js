//service
function onService() {
  $("#sender-info").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  $("#purchase-product").addClass("step-hidden");
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
onService();

//service -> product
function onProduct() {
  $("#select-service").addClass("step-hidden");
  $("#sender-info").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  $("#right-image").addClass("step-hidden");
  if ($("#purchase-product").hasClass("step-hidden"))
    $("#purchase-product").removeClass("step-hidden");
  if (!$("#processing-step-2").hasClass("activated-step")) {
    $("#processing-step-2").addClass("activated-step");
  }
  $("#processing-step-3").removeClass("activated-step");
  $("#processing-step-4").removeClass("activated-step");
  $("#processing-step-5").removeClass("activated-step");
}
$("#btn-service-next").on("click", () => {
  onProduct();
});

//product -> sender
function onSender() {
  $("#select-service").addClass("step-hidden");
  $("#purchase-product").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  if ($("#sender-info").hasClass("step-hidden"))
    $("#sender-info").removeClass("step-hidden");
  if ($("#right-image").hasClass("step-hidden"))
    $("#right-image").removeClass("step-hidden");
  if (!$("#processing-step-3").hasClass("activated-step")) {
    $("#processing-step-3").addClass("activated-step");
  }
  $("#processing-step-4").removeClass("activated-step");
  $("#processing-step-5").removeClass("activated-step");
}
$("#btn-product-next").on("click", () => {
  onSender();
});
$("#btn-product-back").on("click", () => {
  onService();
});

//sender -> receiver
function onReceiver() {
  $("#select-service").addClass("step-hidden");
  $("#purchase-product").addClass("step-hidden");
  $("#sender-info").addClass("step-hidden");
  $("#payment-process").addClass("step-hidden");
  if ($("#receiver-info").hasClass("step-hidden"))
    $("#receiver-info").removeClass("step-hidden");
  if ($("#right-image").hasClass("step-hidden"))
    $("#right-image").removeClass("step-hidden");
  if (!$("#processing-step-4").hasClass("activated-step")) {
    $("#processing-step-4").addClass("activated-step");
  }
  $("#processing-step-5").removeClass("activated-step");
}
$("#btn-sender-next").on("click", () => {
  onReceiver();
});
$("#btn-sender-back").on("click", () => {
  onProduct();
});

//receiver ->  payment
function onPayment() {
  $("#select-service").addClass("step-hidden");
  $("#purchase-product").addClass("step-hidden");
  $("#sender-info").addClass("step-hidden");
  $("#receiver-info").addClass("step-hidden");
  $("#right-image").addClass("step-hidden");
  if ($("#payment-process").hasClass("step-hidden"))
    $("#payment-process").removeClass("step-hidden");
  $("#processing-step-5").addClass("activated-step");
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
});

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
let records =
  document.getElementById("add-person-info").childElementCount - 1 ?? 0;
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

function receiverInfo(index) {
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
                    <span
                        class="postoffice-form-control-wrap">
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
                            class="postoffice-form-control-wrap">
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
                            class="postoffice-form-control-wrap">
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
                        type="text" name="length-${index}"
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
    </div>
    <div class="m-0 mb-5 step-hidden" id="receiver-photo-${index}" style="background-color: #ffdc39; padding: 10px; overflow: scroll hidden;">
        <div id="photo-scroll-${index}"
            class="align-items-center d-flex p-0">

        </div>
    </div>`;
}
let btnBack = `<input type="button" value="BACK" id="btn-receiver-back" class="mr-3">`;
let btnNext = `<input type="button" value="NEXT" id="btn-receiver-next">`;
function loadBtnDelete(index) {
  return `<div class="d-flex align-items-center" id="div-remove-record-${index}" 
                style="position: absolute;top: 85px;left: -55px;"></div>`;
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
        );
    });
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
    loadReceiverForm(`add-person-info-${index}`, "");
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
  let records =
    document.getElementById("add-person-info").childElementCount - 1;
  document
    .getElementById("div-btn-add")
    .insertAdjacentHTML(
      "afterbegin",
      `<p class="mb-0 mr-4">Total receivers: <span>${records}</span></p>`
    );
  document.getElementById("div-btn-add").appendChild(btnAddMorePerson);
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
let serviceId = 0;
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
        let li = `<li style="padding: 0 20px;font-size: 14px;" id="selected-service-${count}">
                            <a role="button">${item.name}</a>
                        </li>`;
        $("#service-list").children("ul").find("div").append(li);
        $(`#selected-service-${count}`).on("click", () => {
          serviceId = item.id;
          $("#select-service").find("button").text(item.name);
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
      $("#product-cate-list").children("ul").find("div").empty()
      $("#product-cate-list").children("ul").find("div")
        .append(`<li style="padding: 0 20px;font-size: 13px;" id="product-cate-0" data-name="All">
                                                                            <a role="button" onClick="getProductByPCate(0)">All</a>
                                                                        </li>`)
      response.forEach((item) => {
        let li = `<li style="padding: 0 20px;font-size: 13px;" id="product-cate-${item.id}" data-name="${item.name}">
                            <a role="button" onClick="getProductByPCate(${item.id})">${item.name}</a>
                        </li>`
        $("#product-cate-list").children("ul").find("div").append(li)
      });
    },
    error: function (data) {
      alert(data.responseText.message)
    },
  });
}
getProductCateList(0)
function getProductByPCate(pCateId) {
  $("#product-cate-list").find("button").text($(`#product-cate-${pCateId}`).attr('data-name'));
  console.log($(`#product-cate-${pCateId}`).attr('data-name'))
  $.ajax({
    url: "Product/GetProductsByPCate?categoryId=" + pCateId,
    type: "get",
    dataType: "json",
    contentType: "application/json",
    success: function (response) {
      $("#div-product").empty();
      response.forEach((item) => {
        let li = `<li id="li-product-${item.id}" class="col-sm-12 mb-3" data-photo="../../img/ProductThumbnail/${item.thumbnail}" data-name="${item.name}" data-code="${item.code}" 
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
                                <p class="m-0" id="attr-name-${item.id}">${item.name}</p>
                                <p class="m-0" id="attr-code-${item.id}" style="font-size: 10px;">#${item.code}</p>
                            </div>
                            <div class="input-group" style="margin-bottom: 0 !important;width: 30%; flex:2;" id="div-attribute-${item.id}">
                                
                            </div>
                            <p class="m-0" style="flex:1;" id="attr-qty-${item.id}" data-qty="${item.qty}">${item.qty} item(s) left</p>
                            <p class="m-0" style="flex:1;" id="attr-price-${item.id}" data-price="${item.price}">${item.price.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'})}</p>
                            <div style="flex: 1;height: 30px;padding: 0 12px;" class="d-flex" id="modify-qty-${item.id}">
                                <button class="btn btn-sm btn-outline-danger" onClick="substractQty(${item.id})" type="button"><i class="fa-solid fa-minus"></i></button>
                                <input type="text" value="1" style="padding: 0 5px;" class="text-center" onkeyup="modifyQty(${item.id})"/>
                                <button class="btn btn-sm btn-outline-dark" onClick="addQty(${item.id})" type="button"><i class="fa-solid fa-plus"></i></button>
                            </div>
                            <button class="btn" id="btn-add-to-cart-${item.id}" style="background-color: #ffdc39;height: 30px;font-size: 12px;" type="button"
                                    onClick="addToCart(${item.id})">
                                <i class="fa-solid fa-basket-shopping"></i>
                            </button>
                        </div>
                    </div>
                  </li>`;
        $("#div-product").append(li);
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
                        <div class="dropdown" id="product-attribute-list-${productId}" style="height: 40px;">
                            <a class="btn dropdown-toggle p-0 tg-pattribute"
                                href="#" role="button"
                                id="select-product-attribute-${productId}"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                                style="height: 100%; width: 100%; overflow: hidden;">
                                <button style="background-color: transparent;color: #111;width: 100%;text-align: left;font-size: 11px;padding: 12px 10px;"
                                    class="btn-sm d-flex">Select product attribute</button>
                            </a>
                            <ul class="dropdown-menu p-0 ul-dropdown"
                                aria-labelledby="select-product-attribute-${productId}"
                                style="height: 142px; width: 100%; border-radius: 0px; line-height: 40px; overflow: hidden">
                                <li style="padding: 0 10px;font-size: 12px;">
                                    --Select product attribute</li>
                                    <div style="overflow: hidden scroll;height: 105px;font-size: 13px;padding: 0 0 0 12px;margin-top: -4px;" 
                                        id="div-product-attribute-${productId}"> 
                                        
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
              $(`#select-product-attribute-${productId}`).children('button').empty()
              $(`#select-product-attribute-${productId}`).children('button').append(text)
              $(`#attr-qty-${productId}`).text(response[0].qty+" item(s) left")
              $(`#attr-price-${productId}`).text(response[0].price.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
              $(`#attr-qty-${productId}`).attr('data-qty', response[0].qty)
              $(`#attr-price-${productId}`).attr('data-price', response[0].price)

              //updateProductLiBySelectAttribute
              $(`#li-product-${productId}`).attr('data-color', response[0].colorValue)
              $(`#li-product-${productId}`).attr('data-length', response[0].lengthValue)
              $(`#li-product-${productId}`).attr('data-width', response[0].widthValue)
              $(`#li-product-${productId}`).attr('data-height', response[0].heightValue)
              $(`#li-product-${productId}`).attr('data-price', response[0].price)
              $(`#li-product-${productId}`).attr('data-attributeId', response[0].id)
            }
            $(`#div-product-attribute-${productId}`).empty()
            response.forEach(item=>{
              //change qty+price by attr
                let li = `<li id="li-attribute-${item.id}">
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
                $(`#div-product-attribute-${productId}`).append(li)
            })
        },
        error: function(data){
            alert(data.responseText.message)
        }
  })
}

function selectAttribute(attributeId, productId){
  let item = $(`#li-attribute-${attributeId}`).children('a')
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
  $(`#select-product-attribute-${productId}`).children('button').empty()
  $(`#select-product-attribute-${productId}`).children('button').append(text)
  $(`#attr-qty-${productId}`).text(qty+" item(s) left")
  $(`#attr-price-${productId}`).text(parseFloat(price).toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#attr-qty-${productId}`).attr('data-qty', qty)
  $(`#attr-price-${productId}`).attr('data-price', price)
  $(`#modify-qty-${productId}`).children('input').val(1)

  //updateProductLiBySelectAttribute
  $(`#li-product-${productId}`).attr('data-color', color)
  $(`#li-product-${productId}`).attr('data-length', length)
  $(`#li-product-${productId}`).attr('data-width', width)
  $(`#li-product-${productId}`).attr('data-height', height)
  $(`#li-product-${productId}`).attr('data-price', price)
  $(`#li-product-${productId}`).attr('data-attributeId', attributeId)
}

//change qty
function substractQty(productId){
  let qty = $(`#modify-qty-${productId}`).children('input')
  if(qty.val().trim() == "") qty.val(1)
  if(parseInt(qty.val()) > 1){
    qty.val(parseInt(qty.val()) - 1)
  } else {
    $(`#li-product-${productId}`).attr('data-qty', qty.val())
    return
  }
  $(`#li-product-${productId}`).attr('data-qty', qty.val())
}

function addQty(productId){
  let qty = $(`#modify-qty-${productId}`).children('input')
  let stock = $(`#attr-qty-${productId}`).attr('data-qty')
  if(qty.val().trim() == "") qty.val(0)
  if(parseInt(qty.val()) < stock){
    qty.val(parseInt(qty.val()) + 1)
  } else {
    $(`#li-product-${productId}`).attr('data-qty', qty.val())
    return
  }
  $(`#li-product-${productId}`).attr('data-qty', qty.val())
}

let regexQty = new RegExp("^[0-9]*$")
function modifyQty(productId){
  let input = $(`#modify-qty-${productId}`).children('input')
  let stock = $(`#attr-qty-${productId}`).attr('data-qty')
  if(regexQty.test(input.val())){
    if(parseInt(input.val()) > parseInt(stock)) input.val(stock)
    if(parseInt(input.val()) < 1) input.val(1)
  } else input.val(1)
  $(`#li-product-${productId}`).attr('data-qty', input.val())
}

//add to cart
let totalcart = 0
totalCart()
function addToCart(productId){
  let rows = parseInt($('#tbody-product').attr('data-rows'))
  if(rows == 0) $('#tbody-product').children('#tbody-default').remove()

  let photo = $(`#li-product-${productId}`).attr('data-photo')
  let name = $(`#li-product-${productId}`).attr('data-name')
  let code = $(`#li-product-${productId}`).attr('data-code')
  let qty = $(`#li-product-${productId}`).attr('data-qty')
  let price = $(`#li-product-${productId}`).attr('data-price')
  let attribute = $(`#li-product-${productId}`).attr('data-attributeId')
  let color = $(`#li-product-${productId}`).attr('data-color')
  let length = $(`#li-product-${productId}`).attr('data-length')
  let width = $(`#li-product-${productId}`).attr('data-width')
  let height = $(`#li-product-${productId}`).attr('data-height')
  let productAttribute = productId+(attribute != '' ? "-"+attribute : '-0')
  let subtotal = parseFloat(price)*parseInt(qty)
  let tr = `<tr class="postalservice-cart-form__cart-item cart_item" data-product="${productId}" data-photo="${photo}" data-code="${code}"
                data-name="${name}" data-qty="${qty}" data-price="${price}" data-subtotal="${subtotal}"
                data-attribute=""  data-color="${color}" data-length="${length}"
                data-width="${width}" data-height="${height}" id="tr-product-${productAttribute}">
              <td class="product-remove">
                <button id="btn-remove-product-${productAttribute}" 
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
                <div style="height: 15px;width: 15px;${(color != undefined && color != 'null')? "background-color: "+color+";" : ""}" 
                  class="mr-2 ${(color != undefined && color != 'null')? "d-block" : "d-none"}"></div>
                <p class="mb-0">${(length != undefined && length != 'null') ? "L:"+length : ""} ${(width != undefined && width != 'null') ? "W:"+width : ""} ${(height != undefined && height != 'null') ? "H:"+height : ""}</p>
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
                    id="cart-qty-${productAttribute}">
                </div>
              </td>
              <td class="product-subtotal">
                <span class="postalservice-Price-amount amount">
                ${subtotal.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'})}
                </span>
              </td>
            </tr>`
  let trProduct = `tr-product-${productAttribute}`
  let cartQty = `cart-qty-${productAttribute}`
  if($('#tbody-product').find(`#${trProduct}`).length && $('#tbody-product').find(`#${trProduct}`).attr('data-attribute') == '' || 
     $('#tbody-product').find(`#${trProduct}`).length && $('#tbody-product').find(`#${trProduct}`).attr('data-attribute') == attribute){
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
            toastAlert('Product quantity', `Quantity must not exceed ${response.qty}`, info)
            cummulativeQty = response.qty - cummulativeQty
            console.log(cummulativeQty+"x"+price)
            $(`#${cartQty}`).attr('value', response.qty)
            $(`#${cartQty}`).val(response.qty )
            $(`#${trProduct}`).attr('data-qty', response.qty)
            $(`#${trProduct}`).attr('data-subtotal', response.qty*price)
            $(`#${trProduct}`).find('.product-subtotal span').text((response.qty *price).toLocaleString('vi-VN', {style: 'currency', currency: 'VND'}))
            totalcart += (parseFloat(price)*parseInt(cummulativeQty))
            updateTotal(productAttribute, response.qty)
        } else {
          cummulativeQty += parseInt(qty)
          console.log(cummulativeQty)
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
    $('#tbody-product').append(tr)
    $('#tbody-product').attr('data-rows', (rows + 1))
    $(`#${trProduct}`).attr('data-attribute', attribute)
    totalcart += (parseFloat(price)*parseInt(qty))
    totalCart()
  }
}

let emptyCart = `<tr id="tbody-default"><td colspan="7" class="text-center">Empty cart</td></tr>`

//removeProduct
function removeProduct(productId, attributeId){
  let productAttribute = productId+(attributeId != '' ? "-"+attributeId : '-0')
  let trProduct = `tr-product-${productAttribute}`
  console.log(trProduct)
  let subtractPrice = $('#tbody-product').children(`#${trProduct}`).attr('data-subtotal')
  $('#tbody-product').children(`#${trProduct}`).remove()
  let rowCount = document.getElementById('tbody-product').childElementCount ?? 0
  if(rowCount == 0) {
    $('#tbody-product').append(emptyCart)
    $('#tbody-product').attr('data-rows', rowCount)
    totalcart = 0
    totalCart()
    return
  }
  $('#tbody-product').attr('data-rows', document.getElementById('tbody-product').childElementCount)
  totalcart -= subtractPrice
  totalCart()
}

//change qty in cart
function changeCartQty(productId, attributeId){
  let urlchangeCartQty = attributeId == '' ? ('Product/GetProduct?productId='+productId) : ('Product/GetProductAttribute?attributeId='+parseInt(attributeId))
  let cartQty = productId+(attributeId != '' ? "-"+attributeId : '-0')
  let qty = $(`#cart-qty-${cartQty}`)
  if(regexQty.test(qty.val())){
    if(parseInt(qty.val()) < 1) 
      qty.val(1)
    if(parseInt(qty.val()) == 1)
      updateTotal(cartQty, 1)
    if(parseInt(qty.val()) > 1){
      $.ajax({
        url: urlchangeCartQty,
        type: 'get',
        dataType: 'json',
        contentType: 'application/json',
        success: function(response){
          if(parseInt(qty.val()) > response.qty){
              toastAlert('Product quantity', `Quantity must not exceed ${response.qty}`, info)
              qty.val(response.qty)
              updateTotal(cartQty, response.qty)
          } else updateTotal(cartQty, parseInt(qty.val()))
        },
        error: function(data){
          alert(data.responseText.message)
        }
      })
    }
  }
}

//cart total
function updateTotal(id, qty){
  let subtractSubtotal = $(`#tr-product-${id}`).attr('data-subtotal')
  let subtotal = parseFloat($(`#tr-product-${id}`).attr('data-price'))*parseInt(qty)
  $(`#tr-product-${id}`).children('.product-subtotal').find('span').text(subtotal.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $('#tbody-product').children(`#tr-product-${id}`).attr('data-subtotal', subtotal)
  totalcart = totalcart - subtractSubtotal + subtotal
  totalCart()
}
function totalCart(){
  $(`#tbody-total-cart`).children('.cart-subtotal').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
  $(`#tbody-total-cart`).children('.order-total').find('span').text(totalcart.toLocaleString('vi-VN', {style : 'currency', currency : 'VND'}))
}

//toast
const error = 0
const success = 1
const info = 2
const warning = 3
function toastAlert(title, message, status){
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
    position : {left:600,top:120},
    stack: false,
    allowToastClose: true,
    showHideTransition: 'fade',
    hideAfter: 3000,
    icon : icon
  })
}

window.addEventListener("click", function (e) {
  if (document.getElementById("product-cate-list").contains(e.target)) {
    $("#product-cate-list").children("ul").css("display", "block");
  } else {
    $("#product-cate-list").children("ul").css("display", "none");
  }
  if (document.getElementById("product-list").contains(e.target)) {
    $("#product-list").children("ul").css("display", "block");
  } else {
    $("#product-list").children("ul").css("display", "none");
  }
});

//sender
