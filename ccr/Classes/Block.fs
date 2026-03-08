module Block

type BlockClass(
    name: string,
    color: string,
    isSolid: bool,
    isTransparent: bool,
    isOpaque: bool,
    isFlammable: bool,
    isReplaceable: bool,
    isAir: bool,
    isLiquid: bool,
    isSolidOnTop: bool
) =
    member this.Name = name
    member this.Color = color
    member this.IsSolid = isSolid
    member this.IsTransparent = isTransparent
    member this.IsOpaque = isOpaque
    member this.IsFlammable = isFlammable
    member this.IsReplaceable = isReplaceable
    member this.IsAir = isAir
    member this.IsLiquid = isLiquid
    member this.IsSolidOnTop = isSolidOnTop