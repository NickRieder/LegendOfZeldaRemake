using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class SetPreviousBlock : ICommand
    {
        private Block block;
        public SetPreviousBlock(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            //block.PreviousBlock();
        }
    }
}
