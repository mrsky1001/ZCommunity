function myFunc(input) {

    var files = input.files || input.currentTarget.files;

    var reader = [];
    var images = document.getElementById('images');
    var name;
    for (var i in files) {
        if (files.hasOwnProperty(i)) {
            name = 'file' + input.files[i].name;

            reader[i] = new FileReader();
            reader[i].readAsDataURL(input.files[i]);

            images.innerHTML += '<img  style="margin: 5px; width: 81px; height: 77px;" id="' + name + '" src="" />';
            (function (name) {
                reader[i].onload = function (e) {
                    console.log(document.getElementById(name));
                    document.getElementById(name).src = e.target.result;
                };
            })(name);


            console.log(files[i]);
        }
    }
}