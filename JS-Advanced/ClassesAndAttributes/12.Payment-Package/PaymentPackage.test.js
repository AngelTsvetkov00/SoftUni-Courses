const { expect, assert } = require('chai');
const PaymentPackage = require('./PaymentPackage');

describe('Payment Package Tests', () => {

    it('should throw error when name is invalid', () => {
        expect(() => {new PaymentPackage('', 12)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage([], 12)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage(12, 12)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage(null, 12)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage({}, 12)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage(undefined, 12)}).to.throw('Name must be a non-empty string');
    });

    it('should throw error when value is invalid', () => {
        expect(() => {new PaymentPackage('ABC', 'ABC')}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('ABC', -1)}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('ABC', {})}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('ABC', [])}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('ABC', null)}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('ABC', undefined)}).to.throw('Value must be a non-negative number');
    });

    it('should throw error when trying to set invalid name', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(() => {testObj.name = ''}).to.throw('Name must be a non-empty string');
        expect(() => {testObj.name = []}).to.throw('Name must be a non-empty string');
        expect(() => {testObj.name = {}}).to.throw('Name must be a non-empty string');
    });

    it('should throw error when trying to set invalid active', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(() => {testObj.active = '3'}).to.throw('Active status must be a boolean');
        expect(() => {testObj.active = 3}).to.throw('Active status must be a boolean');
        expect(() => {testObj.active = {}}).to.throw('Active status must be a boolean');
    });
 
    it('should throw error when trying to set invalid VAT', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(() => {testObj.VAT = ''}).to.throw('VAT must be a non-negative number');
        expect(() => {testObj.VAT = -3}).to.throw('VAT must be a non-negative number');
        expect(() => {testObj.VAT = {}}).to.throw('VAT must be a non-negative number');
    });

    it('should throw error when trying to set invalid value', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(() => {testObj.value = -1}).to.throw('Value must be a non-negative number');
        expect(() => {testObj.value = ''}).to.throw('Value must be a non-negative number');
        expect(() => {testObj.value = {}}).to.throw('Value must be a non-negative number');
    });

    it('should set name properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        testObj.name = 'AAA';
        expect(testObj.name).to.equal('AAA');
    });

    it('should get name properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(testObj.name==='ABC').to.be.true;
        expect(testObj.name).to.equal('ABC');
    });

    it('should set VAT properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        testObj.VAT=120;
        expect(testObj.VAT).to.equal(120);
    });

    it('should set Active properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        testObj.active=false;
        expect(testObj.active).to.equal(false);
    });

    it('should set value properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        testObj.value = 100;
        expect(testObj.value).to.equal(100);
    });

    it('should get value properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(testObj.value).to.equal(12);
    });

    it('should get VAT properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(testObj.VAT).to.equal(20);
    });

    it('should get Active properly', () => {
        let testObj = new PaymentPackage('ABC', 12);
        expect(testObj.active).to.equal(true);
    });

    it('should return proper string when active is false', () => {
        let testObj = new PaymentPackage('ABC', 10);
        testObj.active=false;

        let expectedString=`Package: ABC` + ' (inactive)\n'+
        `- Value (excl. VAT): 10\n`+
        `- Value (VAT 20%): 12`;
        expect(testObj.toString()).to.equal(expectedString);
    });

    it('should return proper string when vat is 0', () => {
        let testObj = new PaymentPackage('ABC', 0);
        testObj.VAT=0;

        let expectedString=`Package: ABC\n`+
        `- Value (excl. VAT): 0\n`+
        `- Value (VAT 0%): 0`;
        expect(testObj.toString()).to.equal(expectedString);
    });

    it('should return proper string when active is true', () => {
        let testObj = new PaymentPackage('ABC', 10);

        let expectedString=`Package: ABC\n`+
        `- Value (excl. VAT): 10\n`+
        `- Value (VAT 20%): 12`;
        expect(testObj.toString()).to.equal(expectedString);
    });

    it('is properly instantiated with two valid parameters', () => {

        const obj = new PaymentPackage('Engineering', 1700);
        expect(obj.name === 'Engineering').to.be.true;
        expect(obj.value === 1700).to.be.true;

    })
})
