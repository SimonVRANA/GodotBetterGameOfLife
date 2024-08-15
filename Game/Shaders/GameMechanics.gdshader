shader_type canvas_item;

uniform vec4 aliveColor : source_color;
uniform vec4 deadColor : source_color;
uniform bool applyGameMechanic= true;


void fragment()
{
	if(applyGameMechanic)
	{
		int numberOfNeighbors= 0;
		for (int i = -1; i < 2; i++)
		{
			for(int j = -1; j <2; j++)
			{
				float iAsFloat= float(i);
				float jAsFloat= float(j);
				vec2 offset= UV + vec2(iAsFloat * TEXTURE_PIXEL_SIZE.x, jAsFloat * TEXTURE_PIXEL_SIZE.y);
				if(offset.x < 0.0f)
				{
					offset= vec2(offset.x + 1.0f, offset.y);
				}
				if(offset.x > 1.0f)
				{
					offset= vec2(offset.x - 1.0f, offset.y);
				}
				if(offset.y < 0.0f)
				{
					offset= vec2(offset.x, offset.y + 1.0f);
				}
				if(offset.y > 1.0f)
				{
					offset= vec2(offset.x, offset.y - 1.0f);
				}
				vec4 neighborColor = texture(TEXTURE, offset);

				if(neighborColor == aliveColor)
				{
					numberOfNeighbors++;
				}
			}
		}

		bool isAlive= (texture(TEXTURE, UV) == aliveColor && (numberOfNeighbors == 2 || numberOfNeighbors == 3))
					  || (texture(TEXTURE, UV) != aliveColor && numberOfNeighbors == 3);

		COLOR = isAlive ? aliveColor : deadColor;
	}
}
