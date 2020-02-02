export class Position {
    public id : number;
    public name :string;
    public description:string;
    public rawPrice: number;
    public retailPrice: number;
    public positionVolume: number;
    public positionCategoryId: number;
    constructor(values:Object={}){
        Object.assign(this,values);
    }
}
