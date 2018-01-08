$(document).ready(function () {

    //https://github.com/bassjobsen/Bootstrap-3-Typeahead
    $.get("example_collection.json", function (data) {
        $("#controller").typeahead({
            source: data,
            afterSelect: function (item) {
                showModalQuantidade();
                console.log(item);
            }
        });
    }, 'json');

    $('#table').bootstrapTable({
        columns: [{
            field: 'id',
            title: 'ID'
        }, {
            field: 'produto',
            title: 'Produto'
        }, {
            field: 'quantidade',
            title: 'Quantidade'
        }, {
            field: 'valor',
            title: 'Valor Unit.'
        }, {
            field: 'valorTotal',
            title: 'Valor'
        }],
        data: []
    });

    $('#controller').keyup(function (e) {
        if (e.which == 13) {
            //alert($('#controller').val());
            showModalQuantidade();
        }
    });

    $('#controller').on('typeahead:selected', function (e, datum) {
        console.log(datum);
    });

    function showModalQuantidade() {
        $('#quantidadeModal').modal('show');
    }
});

/**
 * 
 * $('#table').bootstrapTable('append', [{
            id: 3,
            name: 'Item 3',
            price: '$3.45'
        }])
 */