function customizePhoneNumber(number) {
    return number.value.replace(/\D+/g, '')
        .replace(/(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})/, '+$1 ($2) $3-$4-$5');
}


function showPopupEditNumber(data) {
    var popup = $("#popup-editNumber").dxPopup("instance");
        popup.show();  
    var popupContent = popup.content();
    var form = popupContent.find("#formNumber").dxForm("instance");
    var saveButton = popupContent.find('.modal-footer #saveNumber').dxButton("instance");
    var hId = popupContent.find("input#Id");

    if (!data || isNaN(data.Id)) {
        popup.option("title", "Add phone number");
        form.updateData("Number", '');
        hId.val(0);
    } else {
        popup.option("title", "Edit phone number");
        form.updateData("Number", data.Number);
        form.updateData("UserId", data.UserId);
        hId.val(data.Id);
    }

    DevExpress.utils.resizeCallbacks.fire();
}

function showPopupEditUser(userData) {
    var popup = $("#popup-editUser").dxPopup("instance");
        popup.show();
    var popupContent = popup.content();
    var form = popupContent.find("#formUser").dxForm("instance");
    var saveButton = popupContent.find('.modal-footer #saveUser').dxButton("instance");
    var hId = popupContent.find("input#Id");

    if (!userData || isNaN(userData.Id)) {
        popup.option("title", "Add new user");
        form.updateData({
            FirstName: '',
            FatherName: '',
            Surname: '',
            Address: ''
        });
        hId.val(0);
    } else {
        popup.option("title", "Edit user information");
        form.updateData({
            FirstName: userData.FirstName,
            FatherName: userData.FatherName,
            Surname: userData.Surname,
            Address: userData.Address
        });
        hId.val(userData.Id);
    }

    DevExpress.utils.resizeCallbacks.fire();
}