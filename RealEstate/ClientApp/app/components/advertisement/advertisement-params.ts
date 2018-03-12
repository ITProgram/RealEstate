export class AdvertisementParams
{
    public userId?: number;
    public latitude?: number;
    public longitude?: number;
    public description?: string;
    public minBuidingYear?: number;
    public maxBuidingYear?: number;
    public minCost?: number;
    public maxCost?: number;
    public minFloor?: number;
    public maxFloor?: number;
    public minTotalArea?: number;
    public maxTotalArea?: number;
    public balcony?: boolean
    public minRooms?: number
    public searchField?: string
    public type?: string
    constructor()
    {
    }
}
