export class Advertisement
{
    public id?: number;
    public userId?: number;
    public latitude?: number;
    public longitude?: number;
    public description?: string;
    public constructionYear?: number;
    public cost?: number;
    public floor?: number;//
    public totalArea?: number;//
    public livingArea?: number;//
    public kitchenArea?: number;//
    public balcony?: boolean;//
    public roomsNumber?: number;//+
    public type?: string;
    public elevator?: boolean;
    public stove?: boolean;
    public fridge?: boolean;
    public phone?: string;   //contscts
    public region?: string;
    public district?: string//raion
    public city?: string;
    public street?: string;
    public housing?: string;
    public house?: number;
    public apartment?: number;
    public totalFloors?: number;
    public ceilingHeight?: number;
    public WC?: number;
    constructor()
    {
    }
}
