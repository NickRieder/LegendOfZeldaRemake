using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetNextBlock : ICommand
    {
        private Block block;
        public SetNextBlock(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.NextBlock();
        }
    }
}
