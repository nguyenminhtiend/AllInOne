
$.validator.addMethod("dategreaterthan", function (value, element, params) {
    return Date.parse(value) > Date.parse($(params).val());
});


$.validator.unobtrusive.adapters.add("dategreaterthan", ["otherpropertyname"], function (options) {
    options.rules["dategreaterthan"] = "#" + options.params.otherpropertyname;
    options.messages["dategreaterthan"] = options.message;
});

$.validator.unobtrusive.adapters.addBool("booleanrequired", "required");


$.validator.addMethod("notequalto", function (value, element, params) {
    if (value.indexOf('xxx') > 0) {
        return false;
    }
    if (!this.optional(element)) {
        var otherProp = $('#' + params);
        return (otherProp.val() != value);
    }
    return true;
});
$.validator.unobtrusive.adapters.addSingleVal("notequalto", "otherproperty");

$.validator.addMethod("requiredif", function (value, element, params) {
    if ($(element).val() != '') return true

    var $other = $('#' + params.other);

    var otherVal = ($other.attr('type').toUpperCase() == "CHECKBOX") ?
             ($other.attr("checked") ? "true" : "false") : $other.val();

    return params.comp == 'isequalto' ? (otherVal != params.value)
                      : (otherVal == params.value);
});

$.validator.unobtrusive.adapters.add("requiredif", ["other", "comp", "value"],
  function (options) {
      options.rules['requiredif'] = {
          other: options.params.other,
          comp: options.params.comp,
          value: options.params.value
      };
      options.messages['requiredif'] = options.message;
  }
);