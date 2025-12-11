using UnityEngine;

namespace MiniFarm
{
    public class Cell : CellBase
    {
        [SerializeField] private CellType _cellType;
        [SerializeField] private bool _isLoked = false;

        public override CellType CellType => _cellType;
        public override bool IsLocked => _isLoked;
    }
}