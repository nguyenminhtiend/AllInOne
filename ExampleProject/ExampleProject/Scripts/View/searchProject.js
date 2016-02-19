var ProjectSearch = (function (myModule) {
    var data = {
        ItemPerPage: 10,
        CurrentPage: 0,
        ColumnSort: 1,
        DirectionSort: 'asc',
    };
    myModule.init = function () {
        registerAllEvent();
        loadDataTable(data);
    }
    function registerAllEvent() {
        $("#projectShowSize a").click(function () {
            var size = $(this).attr('data-size');
            data.ItemPerPage = size;
            $("#projectShowSize button span:first-child").html(size);
            var parent = $(this).parents();

            $('#projectShowSize li.active').removeClass('active disabled');
            parent.addClass('active disabled');
            loadDataTable(data);

        });
        
        $("input[type='checkbox']").change(function () {
            alert('ss');
        });
    }
    function loadEvent() {
        $(".pagination li").click(function () {
            if (!$(this).hasClass('disabled') && !$(this).hasClass('active')) {
                data.CurrentPage = $(this).attr("data-page");
                loadDataTable(data);
            }
        });
        $('#listProject table tr th').click(function () {
            alert('aa');
        });
    }
    function loadDataTable(paramRequest) {
        $.ajax({
            url: "/Project/GetProject",
            type: "POST",
            data: paramRequest,
            success: function (result) {
                $('#listProject').html(result);
                loadEvent();
            },
            error: function (e) {

            }
        });
    }

    return myModule;
}(ProjectSearch || {}));