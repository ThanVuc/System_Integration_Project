export interface ShareHolderModel{
    total: number,
    shareHolder: ShareHolder[]
}

export interface ShareHolder{
    shareholderId: number,
    sharesOwned: number,
    name: string
}