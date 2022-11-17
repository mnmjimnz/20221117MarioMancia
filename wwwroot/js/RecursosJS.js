var fun = {
    post: function (data, url, callback) {
        $.post(url, data, function (dat) {
            if (dat != undefined) {
                callback(dat);
            }
        });
    },
    get: function (url, callback) {
        $.get(url, function (data) {
            if (data != undefined) {
                callback(data);
            }
        });
    },
    llenarTablas: function (objetoTabla, botonesArr, param) {
        if (objetoTabla != undefined) {
            let cl = objetoTabla.attr('data-columnas');
            let columnas = cl.split(',');
            this.get(objetoTabla.attr('data-url') + param, function (data) {
                let filas = '<tr>';
                let final = 0;
                data.forEach(function (e) {
                    let value = "";
                    for (var i = 0; i < columnas.length; i++) {
                        value = read_prop(e, columnas[i]).toString();
                        //if (value.includes('/Date')) {
                        //    value = funcionesGlobales.convertirFecha(value);
                        //}
                        filas += '<td class="' + columnas[i] + '">' + value + '</td>';
                        if (columnas.length == i) {
                            final = 1;
                        }
                    }
                    if (final = 1) {
                        //let arrya = [{parametro:1,funcion:'',textoButton:'',classes:''}];
                        if (botonesArr != undefined) {
                            filas += '<td>';
                            botonesArr.forEach(function (k) {
                                let valueFuncion = read_prop(e, k.parametro);
                                filas += '<button type="button" class="' + k.classes + '" onclick="' + k.funcion + '(' + valueFuncion + ')' + '">' + k.textoButton + '</button>';
                            });
                            filas += '</td>';
                        }
                        filas += '</tr>';
                    }
                });
                objetoTabla.children('tbody').html("");
                objetoTabla.children('tbody').append(filas);
            });
        }
    }
}
function read_prop(obj, prop) {
    return obj[prop];
}
function propName(prop, value) {
    for (var i in prop) {
        if (prop[i] == value) {
            return i;
        }
    }
    return false;
}