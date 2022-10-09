//Yiyecek kategorilirini listele
function GetFoodCategories() {
    $.ajax({
        type: "GET",
        url: "DashBoard/GetFoodCategoryList",
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {
            LoadMyContainer(data)
        }
    });
}




$(document).ready(function () {
    GetFoodCategories();
});