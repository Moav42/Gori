export class DrinkCategoryModel {
    public id: number;
    public title: string;
    public description: string;
    constructor(values:Object={}){
        Object.assign(this,values);
    }
}
