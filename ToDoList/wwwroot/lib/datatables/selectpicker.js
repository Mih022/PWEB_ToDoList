(function (factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD
        define(['jquery', 'datatables', 'datatables-editor'], factory);
    }
    else if (typeof exports === 'object') {
        // Node / CommonJS
        module.exports = function ($, dt) {
            if (!$) { $ = require('jquery'); }
            factory($, dt || $.fn.dataTable || require('datatables'));
        };
    }
    else if (jQuery) {
        // Browser standard
        factory(jQuery, jQuery.fn.dataTable);
    }
}
(function ($, DataTable) {
    'use strict';
 
    if (!DataTable.ext.editorFields) {
        DataTable.ext.editorFields = {};
    }
 
    var _fieldTypes = DataTable.Editor ?
        DataTable.Editor.fieldTypes :
        DataTable.ext.editorFields;
 
    _fieldTypes.bootstrap_select = {
        _addOptions: function (conf, options) {
            var elOpts = conf._input[0].options;
            elOpts.length = 0;
            if (options) {
                DataTable.Editor.pairs(options, conf.optionsPair, function (val, label, i) {
                    elOpts[i] = new Option(label, val);
                });
            }
        },
 
        create: function (conf) {
            var editor = this;
            conf._input = $('<select/>')
                .attr($.extend({
                    id: DataTable.Editor.safeId(conf.id),
                    multiple: conf.multiple === true
                }, conf.attr || {}));
 
            if (conf.placeholder !== undefined) {
                conf._input.attr('title', conf.placeholder);
            }
            if (conf.placeholderValue !== undefined) {
                //not implemented
            }
            if (conf.placeholderDisabled !== undefined) {
                //not implemented
            }
 
            _fieldTypes.bootstrap_select._addOptions(conf, conf.options || conf.ipOpts);
 
            // On open, need to have the instance update now that it is in the DOM
            editor.on('open.bootstrap-select' + DataTable.Editor.safeId(conf.id), function () {
                conf._input.selectpicker($.extend({}, conf.opts,
                    {
                        //Default options
                        width: '100%',
                    }));
            });
 
            return conf._input[0];
        },
 
        update: function (conf, options) {
            _fieldTypes.bootstrap_select._addOptions(conf, options);
            $(conf._input).selectpicker('refresh');
        },
 
        get: function (conf) {
            var val = conf._input.val();
            return conf._input.prop('multiple') && val === null ?
                [] :
                val;
        },
 
        set: function (conf, val) {
            conf._input.val(val).trigger('change');
        },
 
        enable: function (conf) {
            $(conf._input).prop('disabled', false);
            $(conf._input).selectpicker('refresh');
        },
 
        disable: function (conf) {
            $(conf._input).prop('disabled', true);
            $(conf._input).selectpicker('refresh');
        },
    };
}));