export class DrinkModel {
    public id: number;
    public name: string;
    public PriceLiter: number;
    public ActualVolume: number;
    public DrinkCategoryId: number;
    constructor(values:Object={}){
        Object.assign(this,values);
    }
}
