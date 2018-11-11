$(function () {
    var win = $(window);

    // Each time the user scrolls
    win.scroll(function () {
        // End of the document reached?
        if ($(document).height() - win.height() == win.scrollTop()) {

            $.ajax({
                url: '/news/allasync?page=' + $("#next-page").val(),
                dataType: 'json',
                success: function (json) {
                    for (var item of json) {
                        $('#news-container .row').append(
                            `<div class="col-sm-4">
                                <div class="card">
                                    <img class="img-responsive card-img-top" src="${item.imageUrl}" alt="No Image" />
                                    <div class="card-body">
                                        <h3 class="card-title">${item.title}</h3>
                                        <p class="card-text">${item.description}</p>
                                        <p class="card-text">Created on: ${item.createdOn}</p>
                                        <br />
                                    </div>
                                </div>
                            </div>`);
                    }
                    var nextPage = Number($("#next-page").val());

                    $("#next-page").val(nextPage + 1);
                }
            });
        }
    });
});