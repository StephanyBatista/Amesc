'use strict';

const BasePo = require("./base.po");

module.exports = class AlunoPo extends BasePo {

    submit() {
        element(by.css('.btn-success')).click();
    }
}